using Assets.Scripts.Data;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Pools;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyInitialization : IExecute
    {
        private readonly Transform _player;
        private EnemyPool _enemyPool;
        private EnemyData _enemyData;
        private float _timer = 0.3f;
        private int _radius = 10;

        public EnemyInitialization(Transform player, EnemyPool enemyPool, EnemyData enemyData)
        {
            _enemyData = enemyData;
            _player = player;
            _enemyPool = enemyPool;
        }

        public void Execute(float deltaTime)
        {
            _timer -= deltaTime;
            if (_timer<0)
            {
                var enemy = _enemyPool.GetFreeElement();
                enemy.gameObject.transform.position = _player.position + (Vector3)(_radius * Random.insideUnitCircle);
            
                _timer = _enemyData.frequency;
            }
        }
    }
}
