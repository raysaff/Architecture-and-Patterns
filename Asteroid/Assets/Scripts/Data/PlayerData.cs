using UnityEngine;


[CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]

public sealed class PlayerData : ScriptableObject, IUnit
{
    [SerializeField, Range(1, 15)]
    private float _speed;

    [SerializeField]
    private Vector2Int _position;

    public Sprite sprite;

    public float Speed => _speed;
    public Vector2 Position => _position;
    
}
