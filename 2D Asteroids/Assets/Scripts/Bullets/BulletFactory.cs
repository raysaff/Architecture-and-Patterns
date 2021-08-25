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
        var gameObjectBuilder = new GameObjectBuilder();

        GameObject bullet = gameObjectBuilder.Visual.Name("Bullet").Tag("Bullet").Sprite(_bulletData.sprite).
                                              Physics.RigidBody2D().CircleCollider2D();

        return bullet;
    }

}
