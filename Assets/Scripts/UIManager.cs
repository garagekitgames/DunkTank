using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    private WorldLevelUIDisplayer worldLevel;
    [SerializeField]
    private SegmentUIDisplayer segmentUI;
    

    public GameObject levelCompleteUI;
    public GameObject levelFailedUI;


    public UnityEvent GotoNextLevel;
    public UnityEvent ReplayLevel;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        StartCoroutine(worldLevel.SetCurrentLevel(LevelManager.instance._currentLevel.value + 1));
        segmentUI.DrawSegments(LevelManager.instance.segmentsPerLevel);
        StartCoroutine(segmentUI.CurrentSegment(LevelManager.instance.currentSegmentCount + 1));

    }

    public void IncrementSegmentUI()
    {
        if(LevelManager.instance.currentSegmentCount + 1 <= LevelManager.instance.segmentsPerLevel)
            StartCoroutine(segmentUI.CurrentSegment(LevelManager.instance.currentSegmentCount + 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCompleteLevelShowUI()
    {
        levelCompleteUI.SetActive(true);
    }

    public void OnLevelFailShowUI()
    {
        levelFailedUI.SetActive(true);
    }


    public void GotoNextLevelButtonPressed()
    {
        levelCompleteUI.SetActive(false);
        GotoNextLevel.Invoke();
    }

    public void ReplayLevelButtonPressed()
    {
        levelFailedUI.SetActive(false);
        ReplayLevel.Invoke();
    }
}
