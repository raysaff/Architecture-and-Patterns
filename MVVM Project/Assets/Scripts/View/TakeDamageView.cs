using UnityEngine;

internal sealed class TakeDamageView : MonoBehaviour
{
    [SerializeField] 
    private float _damage;
    private IHealthViewModel _healthViewModel;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    public void Initialize(IHealthViewModel healthViewModel)
    {
        _healthViewModel = healthViewModel;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.black);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100))
            {
                if (hitInfo.transform.CompareTag("Player"))
                {
                    _healthViewModel.TakeDamage(_damage);
                }
            }
        }
    }
}