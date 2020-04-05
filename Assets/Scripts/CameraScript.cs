using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour {

    // Tweakables
    [Header("Drag")]
    public float dragSpeed = 1;
    [SerializeField] public CameraBounds bounds;
    [Utils.ReadOnly] [SerializeField] Vector2 maxXPositions, maxZPositions;
    [Utils.ReadOnly] [SerializeField] private Vector3 origin;
    [Utils.ReadOnly] [SerializeField] private Vector3 diference;
    public bool drag = false;


    [Header("Zoom")]
    public Vector2 zoomLimits = new Vector2(0.5f, 5f);
    [Range(0.5f, 3f)] public float zoomStep = 0.25f; 
    

    [Header("Focus")]
    [Range(1.0f, 30.0f)] public float focusSpeed = 5f;
    public float elevation = 10;
    public Vector2 focus_offset = new Vector2(6.7f, 6.7f);
    public bool focused; 

    // Main
    Camera cam;

    /* ============================== */
    /* ========== LIFECYCLE ========= */
    /* ============================== */

    private void OnEnable() {
        GameManager._instance.controls.Gameplay.Drag.Enable();
        GameManager._instance.controls.Gameplay.Focus.Enable();
    }

    void Awake () {
        cam = GetComponentInChildren<Camera>();
        GameManager._instance.controls = new InputSetting();
        bounds.Initialize(cam);
        cam.orthographicSize = 5f;
        maxXPositions = bounds.maxXlimit;
        maxZPositions = bounds.maxYlimit;
        
        GameManager._instance.controls.Gameplay.View.performed += _ => OnLook(_);
        GameManager._instance.controls.Gameplay.Drag.performed += _ => OnMouse(_);
        GameManager._instance.controls.Gameplay.Focus.performed += _ => Focus(_);
    }

    void Start () {
        Focus(new InputAction.CallbackContext());
    }

    void Update() {
        // zooming
        /* if (Input.GetAxis("Mouse ScrollWheel") > 0)
            cam.orthographicSize -= zoomStep;
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
            cam.orthographicSize += zoomStep;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, zoomLimits[0], zoomLimits[1]); */
        GameManager._instance.cam_angle = transform.rotation;
    }

	void LateUpdate () {
        // Process movement
        if (!GameManager._instance.player.Equals(null)) {
            if (drag)
                transform.position = Vector3.Lerp(origin, transform.position - diference, dragSpeed * Time.deltaTime);
            if (focused) {
                var p_pos = GameManager._instance.player.transform.position;
                transform.position = Vector3.Lerp(transform.position, new Vector3(p_pos.x - focus_offset.x, 0, p_pos.z - focus_offset.y), Time.deltaTime * focusSpeed);
            } else {

            }
        }
	}
    private void OnDisable() {
        GameManager._instance.controls.Gameplay.View.Disable();
        GameManager._instance.controls.Gameplay.Drag.Disable();
    }

    /* ============================== */
    /* =========== EVENTS =========== */
    /* ============================== */

    /// <summary>
    /// Used to trigger drag mechanic
    /// </summary>
    public void OnMouse(InputAction.CallbackContext ctx) {
        Debug.Log("Clicked");
        GameManager._instance.controls.Gameplay.View.Enable();
    }

    /// <summary>
    /// Processes mouse delta to rig movement vector
    /// </summary>
    public void OnLook(InputAction.CallbackContext ctx) {
        Vector2 m_pos = ctx.ReadValue<Vector2>();
        diference = transform.rotation * new Vector3(m_pos.x, 0, m_pos.y);
        origin = transform.position;
        focused = false;
        drag = true;
        if (!Mouse.current.leftButton.isPressed) {
            GameManager._instance.controls.Gameplay.View.Disable();
            drag = false;
        }
    }

    /// <summary>
    /// Focusses camera to player's position
    /// </summary>
    void Focus(InputAction.CallbackContext ctx) {
        if (!focused) {
            focused = true;
            Debug.Log("Camera focused");
        }
    }
}
