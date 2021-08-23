using UnityEngine;

public class ShootController : IExecute
{
    private BulletData _bulletData;

    private readonly Transform _unit;
    private bool _fire = false;
    private Vector3 _mousePosition;
    private IUserShoots _shoot;
    private readonly Transform _bulletStartPosition;
    private Rigidbody2D _bulletRB;
    private PoolMono<BulletController> _bulletPool;

    public ShootController(IUserShoots shoot, Transform unit, BulletData data, PoolMono<BulletController> bulletPool)
    {
        _bulletPool = bulletPool;
        _bulletPool.autoExpand = bulletPool.autoExpand;
        _bulletData = data;
        _shoot = shoot;
        _unit = unit;
        _bulletStartPosition = _unit.GetChild(2);
        _shoot.TakeShoot += Shooting;
    }

    private void Shooting(float[] values)
    {
        _fire = true;
        _mousePosition.Set(values[0], values[1], 0.0f);
    }


    public void Execute(float deltaTime)
    {
        if (_fire)
        {
            var speed = _bulletData.speed * deltaTime;
            var bullet = _bulletPool.GetFreeElement();
            bullet.gameObject.SetTag("Bullet");
            _bulletPool.autoExpand = _bulletData.autoExpand;
            bullet.transform.position = _bulletStartPosition.position;

            _bulletRB = bullet.GetComponent<Rigidbody2D>();

            Vector3 moveDirection = Camera.main.ScreenToWorldPoint(_mousePosition) - _bulletStartPosition.position;
            _bulletRB.AddForce(moveDirection * speed, ForceMode2D.Impulse);

            _fire = false;
        }
    }
}
