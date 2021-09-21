using Assets.Scripts.BuilderExtensions;
using Assets.Scripts.Data;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {

        private readonly EnemyData _enemyData;

        public EnemyFactory(EnemyData enemyData)
        {
            _enemyData = enemyData;
        }

        public EnemyController CreateEnemy()
        {
            var enemy = _enemyData._prefab;
            enemy.gameObject.SetTag("Enemy").SetActive(false);
            return enemy;
        }
    }
}
