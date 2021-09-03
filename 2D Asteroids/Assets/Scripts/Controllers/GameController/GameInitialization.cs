using UnityEngine;

public sealed class GameInitialization
{
    public GameInitialization(MyControllers controllers, Data data)
    {
        var playerFactory = new PlayerFactory(data.Player);
        var playerInitialization = new PlayerInitialization(playerFactory, data.Player.Position);
        controllers.Add(playerInitialization);

        var inputInitialization = new InputInitialization();
        controllers.Add(inputInitialization);

        controllers.Add(new InputController(inputInitialization.GetInputAxis(), inputInitialization.GetInputDirection(), inputInitialization.GetShoot()));
        controllers.Add(new MoveController(inputInitialization.GetInputAxis(), playerInitialization.GetPlayer(), data.Player));
        controllers.Add(new RotationController(inputInitialization.GetInputDirection(), playerInitialization.GetPlayer()));

        Camera camera = Camera.main;
        controllers.Add(new CameraController(playerInitialization.GetPlayer(), camera.transform));

        var enemyFactory = new EnemyFactory(data.Enemy);
        var enemyPool = new EnemyPool(enemyFactory, data.Enemy.count, NameManager.POOL_ENEMIES);
        controllers.Add(new EnemyInitialization(playerInitialization.GetPlayer(), enemyPool, data.Enemy));

        controllers.Add(new CollisionController(enemyPool));

        var _bulletsPool = new PoolMono<BulletController>(data.Bullet._prefab, data.Bullet.count, NameManager.POOL_BULLETS);
        controllers.Add(new ShootController(inputInitialization.GetShoot(), playerInitialization.GetPlayer(), data.Bullet, _bulletsPool));
    }
}
