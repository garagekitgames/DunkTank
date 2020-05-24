using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WrekBall : MonoBehaviour, ITrap
{
    public Rigidbody wrekBall;

    void Start()
    {
        wrekBall.isKinematic = true;
    }
    public void OnTriggered()
    {
        wrekBall.isKinematic = false;
        Debug.Log("Trigerred");
    }  
    
  
}
