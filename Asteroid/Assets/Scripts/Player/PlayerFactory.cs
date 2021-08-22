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
        return new GameObject("Player").SetTag("Player").AddRigidBody().
               AddSprite(_playerData.sprite).AddSphereCollider().
               AddTrailRenderer().transform;
    }
}
