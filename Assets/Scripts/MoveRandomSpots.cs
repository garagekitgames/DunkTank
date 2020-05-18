using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomSpots : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MoveToRandomSpot", 1f, 2f);
    }

    public void MoveToRandomSpot()
    {
        var xPos = Random.Range(-10.5f, 10.5f);
        var zPos = Random.Range(-10.5f, 10.5f);
        this.transform.position = new Vector3(xPos, transform.position.y, zPos);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
