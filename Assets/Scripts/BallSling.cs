using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSling : MonoBehaviour
{
    public Rigidbody rb;
    public Collider myCollider;
    public Vector3 Position { get { return transform.position; } }
    public Vector3 startPos;

    public void Start()
    {
        startPos = this.transform.position;
    }

    public void Push(Vector3 force)
    {
        rb.AddForce(force, ForceMode.VelocityChange);
    }

    public void ActivateRb()
    {
        rb.isKinematic = false;
    }
    public void DeActivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
    }
}
