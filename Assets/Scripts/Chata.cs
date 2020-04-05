using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(NavMeshObstacle))]
public class Chata : MonoBehaviour, IDamagable
{
    Image hp_bar;

    public int Health {
        get {
            return GameManager._instance.health;
        } set {
            GameManager._instance.health -= value;
            Mathf.Clamp(GameManager._instance.health, 0, Constants.CHATA_HEALTH);
        }
    }

    public void TakeDamage<T>(T dealer) where T : ICanDealDamage
    {
        Health = dealer.Damage;
        if (Health <= 0)
            Die();
    }

    private void Awake() {
        hp_bar = GameObject.FindGameObjectWithTag("hp_bar").GetComponent<Image>();
    }
 
    void Update()
    {
        // Maintain the healthbar
        hp_bar.fillAmount = (float) Health / (float) Constants.CHATA_HEALTH;
    }

    public void Die() {
        // This is the end
        GameManager._instance.game_over_event.Invoke();
    }
}
