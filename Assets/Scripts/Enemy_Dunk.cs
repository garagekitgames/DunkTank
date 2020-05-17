using garagekitgames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dunk : MonoBehaviour
{
    public float enemyHP;
    public bool isEnemyAlive;
    public EnemyRuntimeSet enemyRuntimeSet;


    #region Enemy Spawn 
    public void OnSpawned()
    {
        isEnemyAlive = true;
        enemyRuntimeSet.Add(this);
    }
    #endregion

    #region Enemy Damage and life functions 
    public void OnDamage(float damage)
    {
        enemyHP -= damage;
        CheckAlive();
    }

    public void CheckAlive()
    {
        if (enemyHP <= 0)
        {
            OnDied();
        }
    }

    public void OnDied()
    {
        isEnemyAlive = false;
        enemyRuntimeSet.Remove(this);
        EnemyManager.eManager._listOfDiedEnemy.Add(this.gameObject);
        EnemyManager.eManager.CheckAllEnemiesDiedBeforeReaching();
    }
    #endregion
}
