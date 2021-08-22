using UnityEngine;

public sealed class GameInitialization
{
    public GameInitialization(MyControllers controllers, Data data)
    {
        Camera camera = Camera.main;
        var playerFactory = new PlayerFactory(data.Player);
        var playerInitialization = new PlayerInitialization(playerFactory, data.Player.Position);
        controllers.Add(playerInitialization);

        var inputInitialization = new InputInitialization();
        controllers.Add(inputInitialization);
        controllers.Add(new InputController(inputInitialization.GetInputAxis(), inputInitialization.GetInputDirection(), inputInitialization.GetShoot()));
        controllers.Add(new MoveController(inputInitialization.GetInputAxis(), playerInitialization.GetPlayer(), data.Player));
        controllers.Add(new RotationController(inputInitialization.GetInputDirection(), playerInitialization.GetPlayer()));

        controllers.Add(new ShootController(inputInitialization.GetShoot(), playerInitialization.GetPlayer(), data.Bullet));

        controllers.Add(new CameraController(playerInitialization.GetPlayer(), camera.transform));
    }
}
