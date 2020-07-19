using UnityEngine.Events;

public class EventManager
{
    public static EventManager Instance;

    public EventManager() {
        Instance = Instance ?? this;
    }
    public interface IDE : IEntity, IDamagable {}
    public class DoDamageEvent : UnityEvent<IDE, ICanDealDamage> {};
    public DoDamageEvent OnDamageDone = new DoDamageEvent();
}
