using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using garagekitgames;

public class CharacterHealth : MonoBehaviour
{
    public float startingHealth;
    public float health;
    protected bool dead;
    public event Action OnDeath;

    public RagdollDriver myRagdollDriver;
    private float startMaxTorue, startMaxForce, startMaxJointTorque;

    public List<float> bodyPartHealth = new List<float>();
    public EnemyRuntimeSet enemyRuntimeSet;
    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
        startMaxTorue = myRagdollDriver.maxTorque;
        startMaxForce = myRagdollDriver.maxForce;
        startMaxJointTorque = myRagdollDriver.maxJointTorque;
        this.GetComponent<Enemy_Dunk>().startingHealth = startingHealth;
        this.GetComponent<Enemy_Dunk>().enemyHP = startingHealth;
        this.GetComponent<Enemy_Dunk>().isEnemyAlive = true;
        foreach (var item in myRagdollDriver.slaveBodyParts)
        {
            bodyPartHealth.Add(startingHealth);
        }
    }

    public void OnSpawned()
    {
        health = startingHealth;
        startingHealth = 100;
        dead = false;
        enemyRuntimeSet.Add(this.GetComponent<Enemy_Dunk>());

        if(this.GetComponent<CharacterNavigation>())
        {
            this.GetComponent<CharacterNavigation>().target = LevelManager.instance.currentSegmentObj.goalObject.transform.position;
        }
        //myEnemyController.agent.isStopped = false;
        //myEnemyController.agent.ResetPath();
        //myEnemyController.target = LevelManager.instance.currentSegmentObj.goalObject.transform.position;
        //debugTest.Add("Spawned");
        //myEnemyController.DeactivateRagdoll();
        //CancelInvoke();
        //InvokeRepeating("Yell", Random.Range(3.0f, 10.0f), Random.Range(2.0f, 10.0f));
    }


    public virtual void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection, int teamID, bodyPartType myBodyPartType)
    {
        //TakeDamage(damage);
        var temphealth = 0f;


        for (int i = 0; i < myRagdollDriver.slaveBodyParts.Length; i++)
        {
            if (myRagdollDriver.slaveBodyParts[i].myBodyPartType == myBodyPartType)
            {
                if ((bodyPartHealth[i] - damage * 50) >= 0)
                {
                    bodyPartHealth[i] -= damage * 50;
                    myRagdollDriver.maxTorqueProfile[i] = bodyPartHealth[i] / startingHealth * 100;
                    myRagdollDriver.maxJointTorqueProfile[i] = bodyPartHealth[i] / startingHealth * 1f;
                    myRagdollDriver.maxForceProfile[i] = bodyPartHealth[i] / startingHealth * 1f;
                }

            }

            temphealth += bodyPartHealth[i];
        }

        health = temphealth;

        TakeDamage(damage);
    }

    public virtual void TakeDamage(float damage)
    {
       //play audio
        //AudioManager.instance.Play("Hit");
        
        if((health - damage) >= 0)
        {
            //health -= damage;

            //myRagdollDriver.maxTorque = health / startingHealth * startMaxTorue;
            //myRagdollDriver.maxJointTorque = health / startingHealth * startMaxJointTorque;
            //myRagdollDriver.maxForce = health / startingHealth * startMaxForce;

        }

        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    private void Die()
    {
        //AudioManager.instance.Play("Death");
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        //isEnemyAlive = false;
        //myEnemyController.ActivateRagdoll();
        enemyRuntimeSet.Remove(this.GetComponent<Enemy_Dunk>());
        EnemyManager.eManager.CheckAllEnemiesDiedBeforeReaching();
        //this.GetComponent<Enemy_Dunk>().startingHealth = 0;
        this.GetComponent<Enemy_Dunk>().enemyHP = 0;
        this.GetComponent<Enemy_Dunk>().isEnemyAlive = false;
        //debugTest.Add("Dead");
        //Invoke("DisableEnemy", 3f);
        //Destroy(this.gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
