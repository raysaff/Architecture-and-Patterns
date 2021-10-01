
internal sealed class HealthModel : IHealthModel
{
    public float Health { get; }
    public float CurrentHealth { get; set; }
        
    public HealthModel(float maxHp)
    {
        Health = maxHp;
        CurrentHealth = Health;
    }
}
