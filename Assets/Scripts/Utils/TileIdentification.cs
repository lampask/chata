using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class TileIdentification : WorldObject
{
    [Utils.ReadOnly] public bool ready = false;

    private void Awake() {
        position = GetComponentInParent<Tilemap>().LocalToCell(transform.localPosition);
    }

    public void Refrsh() {
        // In case its needed
        position = GetComponentInParent<Tilemap>().LocalToCell(transform.localPosition);
    }
}
