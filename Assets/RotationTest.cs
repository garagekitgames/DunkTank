using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var delta = 30 * Time.deltaTime;
        transform.localRotation *= Quaternion.Euler(delta, 0, 0); // transform.rotation=
    }
}
