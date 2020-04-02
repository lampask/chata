public interface IDamagable 
{
    int Health { get; set; }
    void TakeDamage<T>(T dealer) where T : ICanDealDamage;
    void Die();
} 
