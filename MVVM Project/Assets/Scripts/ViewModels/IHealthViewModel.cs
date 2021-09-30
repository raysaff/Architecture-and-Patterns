using System;

public interface IHealthViewModel 
{
    IHealthModel HealthModel { get; }
    bool IsDead { get; }
    void TakeDamage(float damage);
    event Action<float> OnDamage;
}
