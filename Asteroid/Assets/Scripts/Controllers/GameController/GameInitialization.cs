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
        controllers.Add(new InputController(inputInitialization.GetInput()));
        controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), data.Player));

    }
}
