using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerTrap : MonoBehaviour, ITrap
{
    public Rigidbody myHandle; 
    

    // Start is called before the first frame update
    void Start()
    {
        myHandle.isKinematic = true;
    }

    public void OnTriggered()
    {
        Debug.Log("Trigerred");
        myHandle.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
