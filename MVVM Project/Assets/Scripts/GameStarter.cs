using UnityEngine;

public class GameStarter : MonoBehaviour
{
    void Start()
    {
        var healthModel = new HealthModel(10);
        var healthViewModel = new HealthViewModel(healthModel);
        FindObjectOfType<HealthView>().Initialize(healthViewModel);
        FindObjectOfType<TakeDamageView>().Initialize(healthViewModel);
    }
}
