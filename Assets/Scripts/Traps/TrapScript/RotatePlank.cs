using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatePlank : MonoBehaviour, ITrap
{
    public GameObject plank;  

    public void OnTriggered()
    {
        // plank.transform.DOLocalRotate(new Vector3(0,0,0),1f).Loops();
        StartCoroutine(RotateFunction());
        Debug.Log("Trigerred");
    }  
    
    public IEnumerator RotateFunction()
    {
        while(true)
        {
            var delta = 200 * Time.deltaTime;
            plank.transform.localRotation *= Quaternion.Euler(delta, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
