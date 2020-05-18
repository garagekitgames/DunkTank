using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject levelCompleteUI;
    public GameObject levelFailedUI;


    public UnityEvent GotoNextLevel;
    public UnityEvent ReplayLevel;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCompleteLevelShowUI()
    {
        levelCompleteUI.SetActive(true);
    }

    public void GotoNextLevelButtonPressed()
    {
        levelCompleteUI.SetActive(false);
        GotoNextLevel.Invoke();
    }

    public void ReplayLevelButtonPressed()
    {

    }
}
