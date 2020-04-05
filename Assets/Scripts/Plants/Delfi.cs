using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delfi : Plant
{
    public float range = 4f;
    private void Update() {
        Collider[] targets = Physics.OverlapSphere(transform.position, range);
        if (targets.Length > 0) {
            //StartCoroutine(Attack());
        }
    }
    /*private IEnumerator Attack() {

    }*/
}
