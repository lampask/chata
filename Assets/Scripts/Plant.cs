using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(BoxCollider))]
public class Plant : WorldObject, IEntity, ICanDealDamage, IDamagable
{
    public Game.EntityType type { get; } = Game.EntityType.PLANT;

    [SerializeField] protected int hp;
    [SerializeField] protected int damage;
    [SerializeField] public int cost;
    public int Health { get { return hp; } set {hp += value;} } 
    public int Damage { get { return damage; } set {damage = value;} }
    [SerializeField] protected int attack_speed;
    [SerializeField] protected Vector2 drop_range;

    protected void Awake() {
        //EventManager.Instance.OnDamageDone.AddListener((EventManager.IDE t, ICanDealDamage u) => TakeDamage(t, u));
        transform.tag = "plant";
        Game.game_over_event.AddListener(() => {
            Destroy(this.gameObject);
        });
    }

    protected void Start() {
        position = new Vector3Int((int) transform.position.x, (int) transform.position.y, (int) transform.position.z);
    }

    public void DoDamage<T>(T target) where T : IDamagable {
        
    }

    public void TakeDamage<T>(T dealer) where T : ICanDealDamage {
        Health = -dealer.Damage;
        if (Health <= 0)
            dealer.EndAttack();
            Die();
    }

    public virtual void EndAttack() { }

    public virtual void Die() {
        /*TileIdentification tile_below = (TileIdentification) GetObjectBelow();
        // remove dig effect
        MeshRenderer mr = tile_below.GetComponent<MeshRenderer>();
        mr.sharedMaterial = Game.tiles.FirstOrDefault(x => x.Value == mr.sharedMaterial).Key;
        // Disable tile
        tile_below.ready = false;*/
        Utils.Drop(transform.position, (int) Random.Range(drop_range.x, drop_range.y));
        Destroy(gameObject);
    }
}
