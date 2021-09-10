using UnityEngine;

public class PlayerFactory : IPlayerFactory
{
    private readonly PlayerData _playerData;

    public PlayerFactory(PlayerData playerData)
    {
        _playerData = playerData;
    }

    public Transform CreatePlayer()
    {
        var player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player")).transform;
        player.gameObject.AddCircleCollider2D().AddRigidBody2D().AddTrailRenderer();
        return player;
    }
}
