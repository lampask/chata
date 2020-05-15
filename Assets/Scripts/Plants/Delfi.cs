using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Delfi : Plant
{
    public float range = 4f;
    bool in_combat = false;
    Component target;

    protected override void Start() {
        base.death_sound = "Delfi_Death";
        base.plant_sound = "Delfi_Sadenie";
        base.attack_sound = "Delfi_Attack";
        base.Start();
    }

    private void Update() {
        if (!in_combat) {
            Collider[] targets = Physics.OverlapSphere(transform.position, range);
            if (targets.Length > 0) {
                try {
                    targets.First(x => x.TryGetComponent(typeof(Enemy), out target));
                    if (target != null) {
                        StartCoroutine(Attack((Enemy) target));
                    }
                    in_combat = true;
                } catch(InvalidOperationException e) {

                }
            }
        } else {
            transform.rotation = Quaternion.LookRotation((target.gameObject.transform.position-transform.position).normalized);
        }
    }

    private IEnumerator Attack(Enemy target) {
        GetComponentInChildren<Animator>().SetTrigger("Attack");
        DoDamage(target);
        if (Vector3.Distance(transform.position, target.transform.position) > range) {
            target = null;
            in_combat = false;
            yield break;
        }
        yield return new WaitForSeconds(attack_speed);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
