using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryDots : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Character"))
        {
            this.gameObject.SetActive(false);
            //this.GetComponent<Renderer>().enabled = false;
        }
       
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            this.GetComponent<Renderer>().enabled = true;
        }
    }
}
