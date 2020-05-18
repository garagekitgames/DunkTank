using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointFix : MonoBehaviour {

     Vector3 strtPos;
     ConfigurableJoint joint;
     Vector3 jointAnchor;
    Vector3 jointNormalAnchor;
    Quaternion strtRot;
    // Use this for initialization
    public bool hip;
    bool started =  false;
    void Start () {

        strtPos = transform.localPosition;
        strtRot = transform.localRotation;

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
        //Debug.Log("PrintOnDisable: script was disabled");
    }

    

    private void OnEnable()
    {
        if (!started)
            return;
        //Debug.Log("PrintOnEnable: script was enabled");
        //if (strtPos == Vector3.zero) return;

        if(!hip)
        {
            transform.localPosition = strtPos;
            transform.localRotation = strtRot;
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
