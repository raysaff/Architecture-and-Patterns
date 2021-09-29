

using Assets.Scripts.Enemy;

namespace Assets.Scripts.Interfaces
{
    public interface IEnemyFactory 
    {
        EnemyController CreateEnemy();
    }
}
