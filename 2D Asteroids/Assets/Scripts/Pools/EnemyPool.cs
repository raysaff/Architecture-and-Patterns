using System;
using System.Collections.Generic;
using Assets.Scripts.Enemy;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Pools
{
    public class EnemyPool : IInit
    {
        public IEnemyFactory _enemyFactory;
        public int _capacity;

        private Transform _container;

        public List<EnemyController> _enemyPool;

        public EnemyPool(IEnemyFactory enemyFactory, int capacity, string poolName)
        {
            _enemyFactory = enemyFactory;
            _capacity = capacity;
            _container = new GameObject(poolName).transform;
            CreateEnemyPool(capacity);
        }

        private void CreateEnemyPool(int capacity)
        {
            _enemyPool = new List<EnemyController>();

            for (int i=0; i<capacity; i++)
            {
                _enemyPool.Add(UnityEngine.Object.Instantiate(_enemyFactory.CreateEnemy(), _container));
            }
        }

        public bool HasFreeElenet(out EnemyController element)
        {
            foreach (var enemy in _enemyPool)
            {
                if (!enemy.gameObject.activeInHierarchy)
                {
                    enemy.gameObject.SetActive(true);
                    element = enemy;
                    return true;
                }
            }
            element = null;
            return false;
        }

        public EnemyController GetFreeElement()
        {
            if (HasFreeElenet(out var element))
                return element;

            throw new Exception($"Нет свободных элементов {typeof(EnemyController)}");
        }

        public void Initialization()
        {
        }
    }
}
