using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SO;
using garagekitgames;
public class Util : MonoBehaviour
{
    public EnemyRuntimeSet enemyRuntimeSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        enemyRuntimeSet.Items.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
