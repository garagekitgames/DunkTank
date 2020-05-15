using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterHealth : MonoBehaviour
{
    public float startingHealth;
    public float health;
    protected bool dead;
    public event Action OnDeath;

    public RagdollDriver myRagdollDriver;
    private float startMaxTorue, startMaxForce, startMaxJointTorque;

    public List<float> bodyPartHealth = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        health = startingHealth;
        startMaxTorue = myRagdollDriver.maxTorque;
        startMaxForce = myRagdollDriver.maxForce;
        startMaxJointTorque = myRagdollDriver.maxJointTorque;

        foreach (var item in myRagdollDriver.slaveBodyParts)
        {
            bodyPartHealth.Add(startingHealth);
        }
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
        //Destroy(this.gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
