using UnityEngine;
using UnityEngine.Events;

public class GameManager_Muthu : MonoBehaviour
{
    public static GameManager_Muthu instance;

    [Header("Script Reference")]
    public HUDController hud;
    public BallManager ballManager;

    public int noOfBallsReleased = 0;

    [Header("Event Reference")]
    public UnityEvent ballReleasedIndicationEvent;

    private void Start()
    {
        instance = this.GetComponent<GameManager_Muthu>();
        hud.DrawNoOfBalls(5);
        ballManager.isBallready = true;
        ballReleasedIndicationEvent.AddListener(BallReleased);
    }    

    public void BallReleased()
    {
        if (noOfBallsReleased < 4)
        {
            noOfBallsReleased++;
            hud.ActiveBalls();
            Invoke("ResetingBall", 3f);
        }
        else
        {
            noOfBallsReleased++;
            hud.ActiveBalls();
        }
    }

    public void ResetingBall()
    {
        ballManager.isBallready = true;
        ballManager.ResetBall();
    }
}
