using UnityEngine;


[CreateAssetMenu(fileName = "BulletSettings", menuName = "Data/BulletSettings")]

public sealed class BulletData : ScriptableObject
{
    [Range(100,1000)]
    public float speed;

    public Sprite sprite;

    public int count;

}
