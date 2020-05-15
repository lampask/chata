using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : Enemy
{
    protected override void Start() {
        base.death_sound = "Dino_Death";
        base.walk_sound = "Dino_Walk";
        base.attack_sound = "Dino_Attack";
        base.Start();
    }

    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
    }
}
