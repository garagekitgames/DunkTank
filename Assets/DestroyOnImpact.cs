using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{
    public float breakForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > breakForce)
        {
            //APR_Player.ActivateRagdoll();
            Destroy(this.gameObject);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
