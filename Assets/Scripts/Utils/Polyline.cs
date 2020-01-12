using UnityEngine;
using System.Collections.Generic;

public class Polyline : MonoBehaviour {
    [Utils.ReadOnly]
    public List<Vector3> nodes = new List<Vector3>(new Vector3[] { new Vector3(-3, 0, 0), new Vector3(3, 0, 0) });
}