using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : Enemy
{
    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
    }

    protected override void OnTriggerExit(Collider other) {
        base.OnTriggerExit(other);
    }
}
