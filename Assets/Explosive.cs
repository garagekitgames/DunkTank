using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.CompareTag("Ball"))
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
            EffectsController.Instance.PlayRandomScreamSound(collision.GetContact(0).point, collision.relativeVelocity.magnitude, collision.transform.tag);

                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
            }
            EffectsController.Instance.CreateExplosionEffect(collision.GetContact(0).point);
            AudioManager.instance.Play("Explosion");
            EffectsController.Instance.PlayRandomScreamSound(collision.GetContact(0).point, collision.relativeVelocity.magnitude, collision.transform.tag);
            //EffectsController.Instance.PlayBallHitSound(collision.GetContact(0).point, collision.relativeVelocity.magnitude, collision.transform.tag);

            Destroy(this.gameObject, 0.5f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
