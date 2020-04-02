using UnityEngine;
using UnityEngine.UI;
public class InventorySelection : MonoBehaviour
{
    int last = 0;
    Image img_holder;

    public float speed = 5f;

    private void Start() {
        img_holder = transform.GetChild((int) Game.player.selection).GetComponent<Image>();    
    }

    void Update()
    {
        if ((int) Game.player.selection != last) {
            img_holder.color = Color.white; // Reset
            img_holder = transform.GetChild((int) Game.player.selection).GetComponent<Image>();
            last = (int) Game.player.selection;
        }
        img_holder.color = new Color(1,1,1, .6f+Mathf.Sin(Time.time*speed)*(1f-.6f)/2);
    }
}
