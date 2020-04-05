using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Utils.ReadOnly] public static GameManager _instance;
    [SerializeField] private List<TileIdentification> restricted_blocks_objs = new List<TileIdentification>();
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private List<Material> materials_o = new List<Material>();

    public enum EntityType {
        PLAYER,
        PLANT,
        ENEMY,
        ENVIROMENT,
        UNMODIFIABLE
    }
    
    [HideInInspector] public UnityEvent game_over_event;
    [HideInInspector] public GameObject tilemap_object;
    [HideInInspector] public GameObject selector_tilemap_object;
    [HideInInspector] public Dictionary<Material, Material> tiles = new Dictionary<Material, Material>();
    [HideInInspector] public Dictionary<int, Dictionary<int, Dictionary<int, WorldObject>>> map;
    [HideInInspector] public List<Vector3Int> restricted_blocks;
    [HideInInspector] public List<IEntity> entities;
    [HideInInspector] public InputSetting controls;
    [HideInInspector] private GameObject p_obj;
    [HideInInspector] public Player player;
    [HideInInspector] public GameTimer main_time;
    [HideInInspector] public Quaternion cam_angle;
    [Utils.ReadOnly] public int health;
    [Utils.ReadOnly] public int essence;
    [Utils.ReadOnly] public bool IsGameOver = false;

    public GameObject game_over;
    public GameObject pause;

    void Awake()
    {
        if (!_instance)
            _instance = this;
        else
            Destroy(this);

        Time.timeScale = 1;

        controls = new InputSetting(); 

        p_obj = GameObject.Instantiate(Imports.PLAYER_OBJ, (Vector3)Constants.PLAYER_STARTING_POSITION+Vector3.up, Quaternion.identity);
        player = p_obj.AddComponent<Player>();

        health = Constants.CHATA_HEALTH;
        essence = Constants.STARTING_ESSENCE;

        // Init Game over condition event
        if (game_over_event == null)
            game_over_event = new UnityEvent();

        game_over_event.AddListener(() => {
            IsGameOver = true;

            //Show UI
            game_over.SetActive(true);
            game_over.GetComponentInChildren<TextMeshProUGUI>().text = main_time.GetComponent<TextMeshProUGUI>().text;
            game_over.GetComponentInChildren<Button>().onClick.AddListener(() => {
                ScreenManager.instance.LoadToMenu(ScreenManager.SceneIndexs.GAME);
            });
            // Freeze time
            Time.timeScale = 0;
        });

        Button[] btns = pause.GetComponentsInChildren<Button>();
        btns[0].onClick.AddListener(() => {
            Time.timeScale = 1;
            pause.SetActive(false);
        });
        btns[1].onClick.AddListener(() => {
            game_over_event.Invoke();
            ScreenManager.instance.LoadToMenu(ScreenManager.SceneIndexs.GAME);
        });

        // SET GAME PROPERIES
        if (!tilemap_object)
            tilemap_object = GameObject.FindGameObjectWithTag("map");
        if (map == null)
            map = Utils.InitializeMap(tilemap_object);
        if (!selector_tilemap_object)
            selector_tilemap_object = GameObject.FindGameObjectWithTag("sel_map");
        if (!main_time) {
            main_time = GameObject.FindGameObjectWithTag("timer").GetComponent<GameTimer>();
        }

        restricted_blocks = restricted_blocks_objs.Select(x => x.position).ToList();
        
        for(int i = 0; i < materials.Count; i++) {
            tiles.Add(materials[i], materials_o[i]);
        }
        //i_selector = GameObject.Find("sgfsg").GetComponent<InteractionSelector>();
        
        Debug.Log("All loaded!");
    }

    void Start() {

    }
}