using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(BoxCollider))]
public class Plant : WorldObject, IEntity, ICanDealDamage, IDamagable
{
    public GameManager.EntityType type { get; } = GameManager.EntityType.PLANT;

    [SerializeField] protected int hp;
    [SerializeField] protected int damage;
    [SerializeField] public int cost;
    public int Health { get { return hp; } set {hp += value;} } 
    public int Damage { get { return damage; } set {damage = value;} }
    [SerializeField] protected int attack_speed;
    [SerializeField] protected Vector2 drop_range;

    protected string death_sound;
    protected string plant_sound;
    protected string attack_sound;

    protected void Awake() {
        //EventManager.Instance.OnDamageDone.AddListener((EventManager.IDE t, ICanDealDamage u) => TakeDamage(t, u));
        transform.tag = "plant";
        GameManager._instance.game_over_event.AddListener(() => {
            Destroy(this.gameObject);
        });
    }

    protected virtual void Start() {
        SoundManager.instance.Play(plant_sound, false, GetComponent<AudioSource>());
        position = new Vector3Int((int) transform.position.x, (int) transform.position.y, (int) transform.position.z);
    }

    public void DoDamage<T>(T target) where T : IDamagable {
        target.TakeDamage(this);
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
        mr.sharedMaterial = GameManager._instance.tiles.FirstOrDefault(x => x.Value == mr.sharedMaterial).Key;
        // Disable tile
        tile_below.ready = false;*/
        Utils.Drop(transform.position, (int) Random.Range(drop_range.x, drop_range.y));
        SoundManager.instance.Play(death_sound, false, GetComponent<AudioSource>());
        Destroy(gameObject);
    }
}
