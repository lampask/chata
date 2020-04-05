public interface ICanDealDamage
{
    int Damage { get; }
    void DoDamage<T>(T target) where T : IDamagable;
    void EndAttack();
}