using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public Vector3Int position;
    protected GameObject prefab;

    public WorldObject GetObjectAbove() {
        return Utils.GetMapObj(position+Vector3.forward);
    }
}
