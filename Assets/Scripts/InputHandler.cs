using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    [SerializeField]
    GameObject crosshairObj;

    [SerializeField]
    GameObject ball;

    Vector3 distance;

    Vector3 previousPos, currentPos;

    public float smoothnessFactor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            //Debug.Log("Initial pos : " + Input.mousePosition);
            if (currentPos == Vector3.zero)
            {
                currentPos = Input.mousePosition;
                return;
            }
            else
            {
                previousPos = currentPos;
                currentPos = Input.mousePosition;
            }


            if(previousPos != Vector3.zero && currentPos != Vector3.zero)
            {
                distance = currentPos - previousPos;
                distance /= smoothnessFactor;
                crosshairObj.transform.position = new Vector3(crosshairObj.transform.position.x + distance.x, crosshairObj.transform.position.y + distance.y, crosshairObj.transform.position.z);
            }

            Debug.Log(distance);

        }
        
        if(Input.GetMouseButtonUp(0))
        {
            ThrowBall();
            currentPos = Vector3.zero;
            previousPos = Vector3.zero;
        }
    }


    void ThrowBall()
    {
        
    }

    private void OnMouseDrag()
    {
        Debug.Log("Drag");
    }
}
