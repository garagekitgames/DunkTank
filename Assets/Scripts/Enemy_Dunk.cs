using garagekitgames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dunk : MonoBehaviour
{
    public float enemyHP;
    public bool isEnemyAlive;
    public EnemyRuntimeSet enemyRuntimeSet;
    public APRController myEnemyController;

    bool canDamage = true;
    #region Enemy Spawn 

    public void OnSpawned()
    {
        isEnemyAlive = true;
        enemyRuntimeSet.Add(this);
        //myEnemyController = this.GetComponent<AP>
        // myEnemyController.target = LevelManager.instance.currentSegmentObj.goalObject.transform;
    }
    #endregion

    #region Enemy Damage and life functions 
    public void OnDamage(float damage)
    {
        if (canDamage)
        {
            enemyHP -= damage;
            print("recoverRoutine "+ recoverRoutine);


            if (recoverRoutine != null)
            {
                print("if");
                StopCoroutine(recoverRoutine);
            }
            else
            {
                print("coroutine start");
                recoverRoutine = StartCoroutine(Recover());
            }
            CheckAlive();
        }


    }
    public Coroutine recoverRoutine;

    IEnumerator Recover()
    {
        print("begin");

        myEnemyController.ActivateRagdoll();
        canDamage = false;
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        myEnemyController.GettingUp = true;
        myEnemyController.balanced = true;
        if (myEnemyController.KnockedOut)
        {

            myEnemyController.DeactivateRagdoll();
        }
        canDamage = true;

        StopCoroutine(recoverRoutine);
        recoverRoutine = null;
        print("null");

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
       // myEnemyController.ActivateRagdoll();
        //Destroy(this.gameObject, 3);
        isEnemyAlive = false;
        enemyRuntimeSet.Remove(this);
        // EnemyManager.eManager._listOfDiedEnemy.Add(this.gameObject);
        EnemyManager.eManager.CheckAllEnemiesDiedBeforeReaching();
    }
    #endregion
}
