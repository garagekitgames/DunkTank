using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var hp = collision.transform.root.GetComponent<Enemy_Dunk>();
            if (hp)
            {
                hp.OnDamage(1000f);
                collision.rigidbody.AddForce(collision.GetContact(0).normal * 10000);
                Debug.Log("HitPlayer");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
