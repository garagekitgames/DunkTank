using UnityEngine;

public class ImpactDetect : MonoBehaviour
{
	public APRController APR_Player;
    public float ImpactForce;
	public float KnockoutForce;
    
    public AudioClip[] Impacts;
    public AudioClip[] Hits;
    public AudioSource SoundSource;

    public Enemy_Dunk myEnemy;
    public BallInfo currentBall;

    public Rigidbody myRb;
    public float impactForce;
    
	void OnCollisionEnter(Collision col)
	{

        if (myEnemy)
        {
            if (col.transform.CompareTag("Ball"))
            {

                myEnemy.OnDamage(currentBall.damage);
                myRb.AddForce(col.GetContact(0).normal * 10000);
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
