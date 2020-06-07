using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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

    public Text levelText;

    [SerializeField]
    GameObject retryLevelFailText;
    [SerializeField]
    GameObject noThanksText;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        StartCoroutine(worldLevel.SetCurrentLevel(LevelManager.instance._currentLevel.value));
        segmentUI.DrawSegments(LevelManager.instance.segmentsPerLevel);
        StartCoroutine(segmentUI.CurrentSegment(LevelManager.instance.currentSegmentCount + 1));

        levelText.text = "Level : " + LevelManager.instance._currentLevel.value;

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
        StartCoroutine(EnableAfterDelay(noThanksText, 1));

    }

    public void OnLevelFailShowUI()
    {
        StartCoroutine(EnableAfterDelay(retryLevelFailText, 1));
    }

    IEnumerator EnableAfterDelay(GameObject _obj, int delay)
    {
        yield return new WaitForSeconds(delay);
        _obj.SetActive(true);
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

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
