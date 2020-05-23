using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class GameFlowController : MonoBehaviour
{
    public float timeLeft = 3.0f;

    public bool gameStarted;
    public Text startText; // used for showing countdown from 3, 2, 1 

    public UnityEvent OnCountdownEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetGameStarted()
    {
        gameStarted = true;
    }
    // Update is called once per frame
    void Update()
    {
        startText.enabled = false;
        if (gameStarted)
        {
            timeLeft -= Time.deltaTime;
            startText.text = (timeLeft).ToString("0");
            startText.enabled = true;
            if (timeLeft < 0)
            {
                startText.enabled = false;
                OnCountdownEnd.Invoke();
                //Do something useful or Load a new game scene depending on your use-case
            }
        }
    }

    public void LevelGenerated()
    {

    }
}
