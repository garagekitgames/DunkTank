using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHealth : MonoBehaviour
{
    public MeshFilter myMesh;
    public int health;
    public Mesh[] damageMesh;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            health++;

            CheckHealth();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        
    }

    public void CheckHealth()
    {
        if (health == 1)
        {
            myMesh.mesh = damageMesh[0];


        }
        else if (health == 2)
        {
            myMesh.mesh = damageMesh[1];

        }
        else if (health == 3)
        {
            myMesh.mesh = damageMesh[2];

        }
    }
}
