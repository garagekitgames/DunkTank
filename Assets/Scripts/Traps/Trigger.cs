using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public GameObject myTrapGO;
    private ITrap myTrap;
    // Start is called before the first frame update
    void Start()
    {
        myTrap = this.GetComponent<ITrap>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(myTrap != null)
            {
                myTrap.OnTriggered();
            }
        }
    }
}
