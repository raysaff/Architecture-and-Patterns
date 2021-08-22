using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
public sealed class Data : ScriptableObject
{
    [SerializeField] 
    private string _playerDataPath;
    private PlayerData _player;

    [SerializeField]
    private string _bulletDataPath;
    private BulletData _bullet;



    public PlayerData Player
    {
        get
        {
            if (_player == null)
            {
                _player = Load<PlayerData>("Data/" + _playerDataPath);
            }

            return _player;
        }
    }

    public BulletData Bullet
    {
        get
        {
            if (_bullet == null)
            {
                _bullet = Load<BulletData>("Data/" + _bulletDataPath);
            }

            return _bullet;
        }
    }




    private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}
