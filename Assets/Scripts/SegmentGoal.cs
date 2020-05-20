using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGoal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            var hp = other.transform.root.GetComponent<Enemy_Dunk>();
            if (hp)
            {
                if(hp.isEnemyAlive)
                {
                    Debug.Log("Failed");
                    LevelManager.instance.levelFailed.Invoke();
                }
            }
                
        }
    }
}
