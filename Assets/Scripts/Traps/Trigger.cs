using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trigger : MonoBehaviour
{

    public GameObject myTrapGO;
    public GameObject myTriggerGO;
    private ITrap myTrap;
    private ITrigger myTrigger;

    // Start is called before the first frame update
    void Start()
    {
        myTrap = myTrapGO.GetComponent<ITrap>();
        myTrigger = myTriggerGO.GetComponent<ITrigger>();
        DOTween.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trap Shot At");
        if (other.transform.CompareTag("Ball"))
        {
            Debug.Log("Trap Shot At" + other.name);
            if (myTrap != null)
            {
                Debug.Log("inside mytrap if");
                myTrap.OnTriggered();
                myTrigger.OnAnimationPlay();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    if(myTrap != null)
        //    {
        //        myTrap.OnTriggered();
        //    }
        //}
    }
}
