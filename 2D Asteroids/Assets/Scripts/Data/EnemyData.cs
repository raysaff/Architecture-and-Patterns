using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Data/Unit/EnemySettings")]

public class EnemyData : ScriptableObject
{
    [SerializeField, Range(10, 1000)]
    public float _speed;

    [SerializeField]
    public EnemyController _prefab;

    [SerializeField, Range(0.1f, 2)]
    public float _mass;

    [SerializeField, Range(0.1f, 5/0f)]
    public float frequency;
    public int count;
}
