using Assets.Scripts.Bullets;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(fileName = "BulletSettings", menuName = "Data/BulletSettings")]

    public sealed class BulletData : ScriptableObject
    {
        [Range(100,1000)]
        public float speed;

        [SerializeField]
        public BulletController _prefab;

        [SerializeField]
        public bool autoExpand;

        public Sprite sprite;

        public int count = 3;

    }
}
