using UnityEngine;
using UnityEngine.UI;
public class InventorySelection : MonoBehaviour
{
    int last = 0;
    Image img_holder;

    public float speed = 5f;
    public float magnitude = .02f;

    private void Start() {
        img_holder = transform.GetChild((int) GameManager._instance.player.selection).GetComponent<Image>();    
    }

    void Update()
    {
        if ((int) GameManager._instance.player.selection != last) {
            img_holder.color = Color.white; // Reset
            img_holder = transform.GetChild((int) GameManager._instance.player.selection).GetComponent<Image>();
            last = (int) GameManager._instance.player.selection;
        }
        img_holder.color = new Color(1,1,1, .6f+Mathf.Sin(Time.time*speed)*(1f-.6f)/2);

        GameManager._instance.selector_tilemap_object.transform.position = Vector3.up*1.05f+Vector3.up*(magnitude*Mathf.Sin(Time.time*speed));
    }
}
