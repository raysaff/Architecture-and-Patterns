using UnityEngine;

public class BulletFactory : IBulletFactory
{
    private readonly BulletData _bulletData;

    public BulletFactory(BulletData bulletData)
    {
        _bulletData = bulletData;
    }
    public GameObject CreateBullet()
    {
        return new GameObject("Bullet").SetTag("Bullet").AddSprite(_bulletData.sprite).AddCircleCollider2D().AddRigidBody2D().AddTrailRenderer();
    }
}
