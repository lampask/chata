using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour, IEntity, IDamagable, ICanDealDamage
{
    public Game.EntityType type { get { return Game.EntityType.ENEMY; } }

    [SerializeField] protected int hp;
    [SerializeField] protected int damage;
    public int Health { get { return hp; } set {hp = value;} } 
    public int Damage { get { return damage; } set {damage = value;} }
    protected NavMeshAgent nava;
    public Polyline trajectory;
    private int current = 0;
    [SerializeField] protected int attack_speed;
    protected void Awake() {
        nava = GetComponent<NavMeshAgent>();
        transform.tag = "enemy";
    }

    protected virtual void Update() {
        if (current < trajectory.nodes.Count-1 && ((nava.pathStatus==NavMeshPathStatus.PathComplete && nava.remainingDistance==0) || nava.pathStatus == NavMeshPathStatus.PathInvalid)) {
            nava.SetDestination(trajectory.gameObject.transform.position+trajectory.nodes[++current]);
        }
    }

    public void DoDamage<T>(T target) where T : IDamagable {
        target.TakeDamage(this);
    }

    public void TakeDamage<T>(T dealer) where T : ICanDealDamage {
        Health -= dealer.Damage;
    }

    protected void OnDestroy() {
        Utils.Drop(transform.position, Random.Range(2,3));
    }

    protected virtual void OnTriggerEnter(Collider other) {
        if (other.CompareTag("plant") || other.CompareTag("chata")) {
            nava.isStopped = true;
            DoDamage(other.gameObject.GetComponent<IDamagable>());
        }
    }

    protected virtual void OnTriggerExit(Collider other) {
        nava.isStopped = false;
    }

    public virtual void Die() {
        Destroy(this);
    }
}
