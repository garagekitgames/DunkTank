using garagekitgames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Dunk : MonoBehaviour
{
    public float enemyHP;
    public bool isEnemyAlive;
    public EnemyRuntimeSet enemyRuntimeSet;
    public APRController myEnemyController;

    bool canDamage = true;
    public Slider hpSlider;
    #region Enemy Spawn 

    public void OnSpawned()
    {
        enemyHP = 100;
        isEnemyAlive = true;
        enemyRuntimeSet.Add(this);
        //myEnemyController.agent.isStopped = false;
        //myEnemyController.agent.ResetPath();
        myEnemyController.target = LevelManager.instance.currentSegmentObj.goalObject.transform.position;
        //myEnemyController.DeactivateRagdoll();

    }
    #endregion

    private void Update()
    {
        hpSlider.value = enemyHP / 100;
        hpSlider.transform.LookAt(Camera.main.transform);
    }
    #region Enemy Damage and life functions 
    public void OnDamage(float damage)
    {
       

        
            enemyHP -= damage;
       
            CheckAlive();
       


    }
    public Coroutine recoverRoutine;

    IEnumerator Recover()
    {

        myEnemyController.ActivateRagdoll();
        canDamage = false;
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));

        if (!myEnemyController.balanced && !myEnemyController.isJumping)
        {
            myEnemyController.GettingUp = true;
            myEnemyController.balanced = true;

            if (myEnemyController.KnockedOut)
            {
                myEnemyController.DeactivateRagdoll();
            }
        }       
        canDamage = true;

        StopCoroutine(recoverRoutine);
        recoverRoutine = null;

    }

    public void CheckAlive()
    {
        if (enemyHP <= 0)
        {
            OnDied();
        }
        else
        {
            if (canDamage)
            {
                if (recoverRoutine != null)
                {
                    StopCoroutine(recoverRoutine);
                }
                else
                {
                    recoverRoutine = StartCoroutine(Recover());
                }
            }
               
        }
    }

    public void OnDied()
    {
        myEnemyController.ActivateRagdoll();
        isEnemyAlive = false;
        enemyRuntimeSet.Remove(this);
        EnemyManager.eManager.CheckAllEnemiesDiedBeforeReaching();
        Invoke("DisableEnemy", 3f);
    }

    public void DisableEnemy()
    {
       
        //EnemyManager.eManager.ReturnToPool(this.gameObject);
        this.gameObject.SetActive(false);
    }
    #endregion
}
