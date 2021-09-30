using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Text _healthText;
    private IHealthViewModel _healthViewModel;

    public void Initialize(IHealthViewModel healthViewModel)
    {
        _healthViewModel = healthViewModel;
        _healthViewModel.OnDamage += OnHealthChange;
        OnHealthChange(_healthViewModel.HealthModel.CurrentHealth);
    }

    private void OnHealthChange(float currentHealth)
    {
        _healthText.text = _healthViewModel.IsDead ? "Game Over" : currentHealth.ToString();
    }

    ~HealthView()
    {
        _healthViewModel.OnDamage -= OnHealthChange;
    }
}
