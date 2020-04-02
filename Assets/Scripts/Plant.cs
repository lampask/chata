using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Collider))]
public class Plant : WorldObject, IEntity, ICanDealDamage, IDamagable
{
    public Game.EntityType type { get; } = Game.EntityType.PLANT;
    public int Damage { get; set; }
    public int Health { get; set; }

    void Awake() {
        //EventManager.Instance.OnDamageDone.AddListener((EventManager.IDE t, ICanDealDamage u) => TakeDamage(t, u));
        transform.tag = "plant";
    }

    public void DoDamage<T>(T target) where T : IDamagable {
        
    }

    public void TakeDamage<T>(T dealer) where T : ICanDealDamage {
        Health -= dealer.Damage;
    }

    public void Drop() {

    }

    void OnDestroy() {
        Drop();
    }

    public virtual void Die() {
        Destroy(this);
    }
}
