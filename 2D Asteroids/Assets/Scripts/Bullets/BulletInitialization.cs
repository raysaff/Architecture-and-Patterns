using UnityEngine;

public class BulletInitialization : IInit
{
    private readonly IBulletFactory _bulletFactory;
    private GameObject __bullet;

    public BulletInitialization(IBulletFactory bulletFactory, Vector2 bulletStartPosition)
    {
        _bulletFactory = bulletFactory;
        __bullet = _bulletFactory.CreateBullet();
        __bullet.transform.position = bulletStartPosition;
    }

    public void Initialization()
    {
    }


    public GameObject GetBullet()
    {
        return __bullet;
    }
}
