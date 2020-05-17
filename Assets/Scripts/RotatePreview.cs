using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePreview : MonoBehaviour
{
   

    void Update()
    {
        if(transform.childCount>0)
        {
            var delta = 30 * Time.deltaTime;
            transform.GetChild(0).gameObject.transform.localRotation *= Quaternion.Euler(delta, delta, delta);
        }
    }
}
