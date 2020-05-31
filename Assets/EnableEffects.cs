using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableEffects : MonoBehaviour
{
    public Rigidbody rb;
    public TrailRenderer trailRend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 5)
        {
            trailRend.enabled = true;
        }
        else
            trailRend.enabled = false;
    }

    private void OnEnable()
    {
        trailRend.Clear();
    }
}
