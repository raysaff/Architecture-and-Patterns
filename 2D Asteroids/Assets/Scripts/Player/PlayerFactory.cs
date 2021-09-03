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
        var player = new GameObject("Player").SetTag("Player")
                                             .AddCircleCollider2D().AddRigidBody2D().AddTrailRenderer().transform;
        player.rotation = Quaternion.Euler(new Vector3(270, 90, -90));

        var sprite = new GameObject("Sprite").AddSprite(_playerData.sprite);
        sprite.transform.SetParent(player.transform);

        var bulletStartPosition = new GameObject("BulletStartPosition");
        bulletStartPosition.transform.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
        bulletStartPosition.transform.SetParent(player.transform);

        player.gameObject.SetAudioClip(Resources.Load<AudioClip>("Sounds/back"));
        return player;
    }
}
