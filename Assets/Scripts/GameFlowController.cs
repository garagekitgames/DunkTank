using Doozy.Engine.Progress;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameFlowController : MonoBehaviour
{
    public float timeLeft = 3.0f;

    public bool gameStarted;
    public Text startText; // used for showing countdown from 3, 2, 1 

    public UnityEvent OnCountdownEnd;

    [Header("Super meter reference")]
    float continuousHit;
    float damagePercentage;
    public float speed;
    public Progressor superMeter;
    public BallInfo currentBall;
    Coroutine ProgresRoutine = null;
    bool isMeterIncreasing;
    bool isMeterReachedTop;

    private void Start()
    {

    }
    public void SetGameStarted()
    {
        gameStarted = true;
        StartCoroutine(DecreaseValue());
    }

    // Update is called once per frame
    private void Update()
    {
        //startText.enabled = false;
        if (gameStarted)
        {
            timeLeft -= Time.deltaTime;
            startText.text = (timeLeft).ToString("0");
            startText.transform.parent.gameObject.SetActive(true);
            if (timeLeft > 0 && timeLeft < 1)
            {
                startText.text = "GO";

                //Do something useful or Load a new game scene depending on your use-case
            }
            if (timeLeft < 0)
            {
                startText.transform.parent.gameObject.SetActive(false);
                OnCountdownEnd.Invoke();
            }
        }
    }

    public void LevelGenerated()
    {

    }

 
    public void AddValueToMeter(float hitValue)
    {
        if(!(isMeterReachedTop))
        {
            if (ProgresRoutine != null)
            {
                StopCoroutine(ProgresRoutine);
            }
            ProgresRoutine = StartCoroutine(SetProgress(hitValue));
        }      

    }


   

    public IEnumerator SetProgress(float hitValue)
    {
        if (continuousHit > 99)
        {
            isMeterReachedTop = true;
            currentBall.reloadingTime = 0f;
            while (continuousHit > 0)
            {
                isMeterIncreasing = true;
                continuousHit = continuousHit - speed * Time.deltaTime;
                print(continuousHit);
                superMeter.SetValue(continuousHit);
                yield return new WaitForSeconds(0.1f);
            }
            continuousHit = 0f;
            hitValue = 0f;
            currentBall.reloadingTime = 0.3f;

        }
        isMeterReachedTop = false;
        isMeterIncreasing = false;

        float temp = 0;
        damagePercentage = continuousHit + hitValue;
        while (temp + 1 < damagePercentage)
        {
            isMeterIncreasing = true;
            temp =Mathf.Lerp(continuousHit,damagePercentage,Time.deltaTime);
            continuousHit = temp;
            superMeter.SetValue(temp);
            yield return new WaitForSeconds(0.01f);
        }
        damagePercentage = 0f;
        isMeterIncreasing = false;
        temp = 0;       
    }

    public IEnumerator DecreaseValue()
    {    
        while (continuousHit > 1 && isMeterIncreasing == false)
        {
            continuousHit = continuousHit - speed * Time.deltaTime;
            superMeter.SetValue(continuousHit);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(DecreaseValue());
    }
}
