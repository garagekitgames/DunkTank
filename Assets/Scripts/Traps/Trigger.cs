using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Trigger : MonoBehaviour
{

    public GameObject myTrapGO;
    private ITrap myTrap;
    // Start is called before the first frame update
    void Start()
    {
        myTrap = myTrapGO.GetComponent<ITrap>();
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
                transform.DOLocalMove(new Vector3(0, -1, 0), 0.5f);
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
