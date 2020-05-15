using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IEntity, IDamagable, ICanDealDamage
{
    public GameManager.EntityType type { get { return GameManager.EntityType.ENEMY; } }

    [SerializeField] protected int hp;
    [SerializeField] protected int damage;
    public int Health { get { return hp; } set {hp = value;} } 
    public int Damage { get { return damage; } set {damage = value;} }
    protected NavMeshAgent nava;
    [HideInInspector] public Polyline trajectory;
    private int current = 0;
    [SerializeField] protected int attack_speed;
    [SerializeField] protected Vector2 drop_range;

    private IDamagable target;

    [SerializeField] [Utils.ReadOnly] private Vector3 destination;

    protected string walk_sound;
    protected string attack_sound;
    protected string death_sound;

    protected virtual void Awake() {
        nava = GetComponent<NavMeshAgent>();
        transform.tag = "enemy";
    }

    protected virtual void Start() {
        GameManager._instance.game_over_event.AddListener(Die);
    }

    protected virtual void Update() {
        if (current < trajectory.nodes.Count-1 && ((nava.pathStatus==NavMeshPathStatus.PathComplete && nava.remainingDistance==0) || nava.pathStatus == NavMeshPathStatus.PathInvalid)) {
            destination = trajectory.gameObject.transform.TransformPoint(trajectory.nodes[++current]);
            SoundManager.instance.Play(walk_sound, true, GetComponent<AudioSource>());
            nava.SetDestination(destination);
        }
    }

    public void DoDamage<T>(T target) where T : IDamagable {
        SoundManager.instance.Play(attack_sound, false, GetComponent<AudioSource>());
        target.TakeDamage(this);
    }

    public void TakeDamage<T>(T dealer) where T : ICanDealDamage {
        Health -= dealer.Damage;
        if (Health <= 0)
            Die();
    }

    protected virtual void OnTriggerEnter(Collider other) {
        if (other.CompareTag("plant") || other.CompareTag("chata")) {
            nava.isStopped = true;
            StartCoroutine(Attack(other.gameObject.GetComponent<IDamagable>()));
        }
    }

    public void EndAttack() {
        nava.isStopped = false;
    }

    protected IEnumerator Attack(IDamagable target) {
        while(target != null && !target.Equals(null)) {
            yield return new WaitForSeconds(attack_speed); 
            try {
                DoDamage(target);
            } catch {
                target = null; // unnecesary
            }
        }
    }

    public void Die() {
        Utils.Drop(transform.position, (int) Random.Range(drop_range.x, drop_range.y));
        StopAllCoroutines();
        SoundManager.instance.Play(death_sound, false, GetComponent<AudioSource>());
        Destroy(gameObject, SoundManager.instance.AudioClips.Find(x => x.name == death_sound).clip.length);
    }
}
