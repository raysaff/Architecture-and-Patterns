using System.Collections.Generic;
using UnityEngine;

public class CollisionController : IInit
{
    private IEnumerable<IEnemy> _enemies;

    public CollisionController(EnemyPool enemyPool)
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
