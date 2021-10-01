using System;

internal sealed class HealthViewModel : IHealthViewModel
{
    private bool _isDead;
    public event Action<float> OnDamage;
    public IHealthModel HealthModel { get; }
    
    public bool IsDead => _isDead;

    public HealthViewModel(IHealthModel hpModel)
    {
        HealthModel = hpModel;
    }
    
    public void TakeDamage(float damage)
    {
        HealthModel.CurrentHealth -= damage;
        if (HealthModel.CurrentHealth <= 0)
        {
            _isDead = true;
        }
        OnDamage?.Invoke(HealthModel.CurrentHealth);
    }
}
