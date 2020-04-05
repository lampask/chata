using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tekvica : Plant
{
    public float damage_radius = 1.5f;
    public override void Die() {
       Collider[] targets = Physics.OverlapSphere(transform.position, damage_radius);
       foreach (Collider target in targets) {
           if (target.tag == "enemy") {
               DoDamage(target.gameObject.GetComponent<Enemy>());
           }
       }
       base.Die();
   }
}
