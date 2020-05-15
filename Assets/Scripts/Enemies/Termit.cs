using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Termit : Enemy
{
    protected override void Start() {
        base.death_sound = "Termit_Death";
        base.walk_sound = "Termit_Walk";
        base.attack_sound = "Termit_Attack";
        base.Start();
    }

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
    }
}
