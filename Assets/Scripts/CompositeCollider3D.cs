using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompositeCollider3D : MonoBehaviour
{
    [Utils.ReadOnly] public bool dynamic = false;

    void Start()
    {
        GenerateCollisionMesh();
    }

    private void GenerateCollisionMesh() {
        List<MeshFilter> meshes = transform.GetComponentsInChildren<MeshFilter>().ToList();
        CombineInstance[] combine = new CombineInstance[meshes.Count].Select(
            (x, index) => {
                x.mesh = meshes[index].sharedMesh; 
                x.transform = meshes[index].transform.localToWorldMatrix; 
                return x; // Create mesh combine instance from mesh filter
            }
        ).ToArray();
        
        Mesh combined = new Mesh(); // Create new mesh to assign
        combined.CombineMeshes(combine); // Oerride creted mesh with combined mesh
        

        MeshCollider collider = GetComponent<MeshCollider>();
        collider.sharedMesh = combined;
        collider.enabled = true;
    } 
}
