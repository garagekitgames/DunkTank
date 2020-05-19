using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointFix : MonoBehaviour {

     Vector3 strtPos;
     ConfigurableJoint joint;
     Vector3 jointAnchor;
    Vector3 jointNormalAnchor;
    Rigidbody myRb;
    Quaternion strtRot;
    // Use this for initialization
    public bool hip;
    bool started =  false;
    void Awake () {

        strtPos = transform.localPosition;
        strtRot = transform.localRotation;

        myRb = transform.GetComponent<Rigidbody>();

        joint = transform.GetComponent<ConfigurableJoint>();

        if(joint)
        {
            jointAnchor = joint.connectedAnchor;
            jointNormalAnchor = joint.anchor;
        }
        
        started = true;
    }

    void OnDisable()
    {
        if (!started)
            return;
        //Debug.Log("PrintOnDisable: script was disabled");
        if (myRb)
        {
            myRb.velocity = Vector3.zero;
            myRb.angularVelocity = Vector3.zero;

        }

        //Debug.Log("PrintOnEnable: script was enabled");
        //if (strtPos == Vector3.zero) return;

        //if(!hip)
        //{
        transform.localPosition = strtPos;
        transform.localRotation = strtRot;
        //}

        if (myRb)
        {
            myRb.velocity = Vector3.zero;
            myRb.angularVelocity = Vector3.zero;

        }
        if (joint)
        {
            joint.connectedAnchor = jointAnchor;
            joint.anchor = jointNormalAnchor;
            joint.autoConfigureConnectedAnchor = false;
        }
    }

    

    private void OnEnable()
    {
        if (!started)
            return;
        //Debug.Log("PrintOnEnable: script was enabled");
        //if (strtPos == Vector3.zero) return;

        //if(!hip)
        //{
            transform.localPosition = strtPos;
            transform.localRotation = strtRot;
        //}
       
        if(myRb)
        {
            myRb.velocity = Vector3.zero;
            myRb.angularVelocity = Vector3.zero;

        }
        if(joint)
        {
            joint.connectedAnchor = jointAnchor;
            joint.anchor = jointNormalAnchor;
            joint.autoConfigureConnectedAnchor = false;
        }
        
    }
    // Update is called once per frame
    void Update () {
        
    }
}
