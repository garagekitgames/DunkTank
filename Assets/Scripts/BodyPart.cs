using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum bodyPartType
{
    head,
    chest,
    hip,
    lArm,
    rArm,
    lForeArm,
    rForeArm,
    lThigh,
    rThigh,
    lLeg,
    rLeg,
    lHand,
    rHand,
    lFoot,
    rFoot
}
public class BodyPart : MonoBehaviour
{
    
    public CharacterHealth myHealth;

    public bodyPartType myBodyPartType;
    // Start is called before the first frame update
    void Start()
    {
        myHealth = this.transform.root.GetComponent<CharacterHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(myHealth)
        {
            if(collision.transform.CompareTag("Ball"))
            {
                myHealth.TakeHit(1, collision.GetContact(0).point, collision.GetContact(0).normal, 0, myBodyPartType);
            }
        }
    }
}
