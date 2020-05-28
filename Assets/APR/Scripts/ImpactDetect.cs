using UnityEngine;
using UnityEngine.Events;
using EZCameraShake;
using DamageEffect;

public class ImpactDetect : MonoBehaviour
{
	public APRController APR_Player;
    public float ImpactForce;
	public float KnockoutForce;
    
    public AudioClip[] Impacts;
    public AudioClip[] Hits;
    public AudioSource SoundSource;

    public Enemy_Dunk myEnemy;
    public CannonInfo currentBall;

    public Rigidbody myRb;
    public float impactForce;

    public UnityEvent OnHitEvent;
    private DamageEffectScript damageEffectScript;

    private void Start()
    {
        //damageEffectScript = transform.root.GetComponent<DamageEffectScript>();
    }
    void OnCollisionEnter(Collision col)
	{
        if (myEnemy)
        {
            if (col.transform.CompareTag("Ball"))
            {

                
                //damageEffectScript.Blink(0, 0.2f);
                if(this.gameObject.name.Contains("APR_Head"))
                {
                    CameraShaker.Instance.ShakeOnce(Random.Range(1f, 1.5f), 10, 0.05f, 0.4f);
                    EffectsController.Instance.PlayBallHitSound(col.GetContact(0).point, col.relativeVelocity.magnitude, col.transform.tag);
                    EffectsController.Instance.PlayHurtSound(col.GetContact(0).point, col.relativeVelocity.magnitude, col.transform.tag);

                    
                    myEnemy.OnDamage(currentBall.damage * 2);
                    myRb.AddForce((col.GetContact(0).normal+Vector3.up)* Random.Range(100f, 150f), ForceMode.VelocityChange);
                }
                else
                {
                    CameraShaker.Instance.ShakeOnce(Random.Range(0.4f, 1f), 10, 0.05f, 0.4f);
                    EffectsController.Instance.PlayBallHitSound(col.GetContact(0).point, col.relativeVelocity.magnitude, col.transform.tag);
                    EffectsController.Instance.PlayHurtSound(col.GetContact(0).point, col.relativeVelocity.magnitude, col.transform.tag);

                    myEnemy.OnDamage(currentBall.damage);
                    myRb.AddForce((col.GetContact(0).normal + Vector3.up) * Random.Range(100f, 150f), ForceMode.VelocityChange);
                }
                
                OnHitEvent.Invoke();

               // myHealth.TakeHit(1, collision.GetContact(0).point, collision.GetContact(0).normal, 0, myBodyPartType);
            }
        }
        //      //Knockout by impact
        //if(col.relativeVelocity.magnitude > KnockoutForce)
        //{
        //	APR_Player.ActivateRagdoll();

        //          if(!SoundSource.isPlaying)
        //          {
        //              int i = Random.Range(0, Hits.Length);
        //              SoundSource.clip = Hits[i];
        //              SoundSource.Play();
        //          }
        //}

        //      //Sound on impact
        //      if(col.relativeVelocity.magnitude > ImpactForce)
        //      {
        //          if(!SoundSource.isPlaying)
        //          {
        //              int i = Random.Range(0, Impacts.Length);
        //              SoundSource.clip = Impacts[i];
        //              SoundSource.Play();
        //          }
        //      }
    }
}
