using garagekitgames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Dunk : MonoBehaviour
{
    public float enemyHP;
    public float startingHealth;
    public bool isEnemyAlive;
    public EnemyRuntimeSet enemyRuntimeSet;
    public APRController myEnemyController;

    bool canDamage = true;
    public Slider hpSlider;

    public List<string> debugTest = new List<string>();
    #region Enemy Spawn 

    public void OnSpawned()
    {
        enemyHP = 100;
        startingHealth = 100;
        isEnemyAlive = true;
        enemyRuntimeSet.Add(this);
        //myEnemyController.agent.isStopped = false;
        //myEnemyController.agent.ResetPath();
        myEnemyController.target = LevelManager.instance.currentSegmentObj.goalObject.transform.position;
        debugTest.Add("Spawned");
        //myEnemyController.DeactivateRagdoll();
        CancelInvoke();
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
        if (isEnemyAlive)
        {
            enemyHP -= damage;
            debugTest.Add("Damaged : " + enemyHP);
            CheckAlive();
            Debug.Log("Damaged : " + enemyHP);
        }

        

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
        if (!(enemyHP <= 0))
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
        else
        {
            if (recoverRoutine != null)
            {
                StopCoroutine(recoverRoutine);
            }

            OnDied();
        }
    }

    public void OnDied()
    {
        isEnemyAlive = false;
        myEnemyController.ActivateRagdoll();    
        enemyRuntimeSet.Remove(this);
        EnemyManager.eManager.CheckAllEnemiesDiedBeforeReaching();
        debugTest.Add("Dead");
        Invoke("DisableEnemy", 3f);
        
    }

    public void DisableEnemy()
    {
        //EnemyManager.eManager.ReturnToPool(this.gameObject);
        
        if(!isEnemyAlive)
        {
            debugTest.Add("Disabled");
            this.gameObject.SetActive(false);
        }
        
    }
    #endregion
}
