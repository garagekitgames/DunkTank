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

    public List<Sprite> happyEmotes = new List<Sprite>();

    public List<Sprite> hurtEmotes = new List<Sprite>();

    public SpriteRenderer emotionRenderer;

    public enum Emotion { happy, hurt}

    public Emotion myEmotion;
    #region Enemy Spawn 

    private void Start()
    {
        //InvokeRepeating("Yell", 3.0f, Random.Range(2.0f, 10.0f));
        emotionRenderer.enabled = false;
    }
    public void OnSpawned()
    {
        emotionRenderer.enabled = false;
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
        InvokeRepeating("Yell", Random.Range(3.0f, 10.0f), Random.Range(2.0f, 10.0f));
    }
    #endregion

    IEnumerator ShowEmote()
    {
        emotionRenderer.enabled = true;

        switch (myEmotion)
        {
            case Emotion.happy:
                emotionRenderer.sprite = happyEmotes[Random.Range(0, happyEmotes.Count - 1)];
                break;

            case Emotion.hurt:
                emotionRenderer.sprite = hurtEmotes[Random.Range(0, hurtEmotes.Count - 1)];
                break;

            default:
                break;
        }

        yield return new WaitForSeconds(1.5f);

        emotionRenderer.enabled = false;

    }

    public void Yell()
    {
        if (isEnemyAlive && !myEnemyController.KnockedOut)
        {
            EffectsController.Instance.PlayRandomLaughSound(myEnemyController.APR_Parts[2].transform.position, Random.Range(1.0f, 10.0f), "yell");
            myEmotion = Emotion.happy;
            //StartCoroutine(ShowEmote());

        }
    }
    private void Update()
    {

        if(hpSlider)
        {
            hpSlider.value = enemyHP / 100;
            hpSlider.transform.LookAt(Camera.main.transform);
        }

        if(emotionRenderer)
        {
            emotionRenderer.transform.LookAt(Camera.main.transform);
        }
        
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

            EffectsController.Instance.slowDownTime(4, 0.02f, 0);
            myEmotion = Emotion.hurt;
            StartCoroutine(ShowEmote());
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
            if(EnemyManager.eManager.useObjectPool)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                Destroy(this.gameObject);
            }
            //
            
        }
        
    }
    #endregion
}
