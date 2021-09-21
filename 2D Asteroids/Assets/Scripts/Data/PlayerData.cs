using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]

    public sealed class PlayerData : ScriptableObject, IUnit
    {
        [SerializeField, Range(30, 100)]
        private float _speed;

        [SerializeField]
        private Vector2Int _position;

        [SerializeField, Range(0,2)]
        private float _mass;

        public Sprite sprite;

        public float Mass => _mass;
        public float Speed => _speed;
        public Vector2 Position => _position;
    
    }
}
