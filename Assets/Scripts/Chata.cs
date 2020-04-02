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
            return Game.health;
        } set {
            Game.health -= value;
            Mathf.Clamp(Game.health, 0, Constants.CHATA_HEALTH);
        }
    }

    public void TakeDamage<T>(T dealer) where T : ICanDealDamage
    {
        Health = dealer.Damage;
        Debug.Log("Got hit");
    }

    private void Awake() {
        hp_bar = GameObject.FindGameObjectWithTag("hp_bar").GetComponent<Image>();
    }
 
    void Update()
    {
        // Maintain the healthbar
        hp_bar.fillAmount = (float) Game.health / (float) Constants.CHATA_HEALTH;
    }

    public void Die() {
        // This is the end
        Game.game_over_event.Invoke();
    }
}
