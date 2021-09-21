using System.Collections.Generic;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Pools;
using UnityEngine;

namespace Assets.Scripts.HW7
{
    public class CollisionObserver : IInit
    {
        private IEnumerable<IEnemy> _enemies;

        public CollisionObserver(EnemyPool enemyPool)
        {
            _enemies = enemyPool._enemyPool;
        }


        public void Initialization()
        {
            foreach (var enemy in _enemies)
            {
                enemy.OnTriggerEnterChange += EnemyOnOnTriggerEnterChange;
            }
        }

        private void EnemyOnOnTriggerEnterChange(string collisionTag)
        {
            if (collisionTag=="Player")
            {
                Debug.Log("Damage");
            }
            else if (collisionTag =="Bullet")
            {
                Debug.Log("Match");
            }

        }


    }
}
