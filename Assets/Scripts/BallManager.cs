using UnityEngine;

public class BallManager : MonoBehaviour
{
    public BallSling ball;
    public Camera cam;
    [SerializeField] private readonly float pushForce = 4f;
    private bool isDragging = false;
    private Vector3 startPoint, endPoint, force, direction;

    public Vector3 minPower, maxPower;
    private float distance;

    public Trajectory trajectory;

    public bool isBallready;

    private void Update()
    {
        if (isBallready)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }
            if (isDragging)
            {
                OnDrag();
            }
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                OnDragEnd();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetBall();
            }
        }

    }

    public void OnDragStart()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float z = 50f;

        ball.DeActivateRb();
        startPoint = cam.ScreenToWorldPoint(new Vector3(x, y, z));
        print(startPoint);
        trajectory.Show();
    }

    public void OnDrag()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float z = 50f;

        endPoint = cam.ScreenToWorldPoint(new Vector3(x, y, z));
        distance = Vector3.Distance(startPoint, endPoint);
        // direction = (startPoint - endPoint).normalized;

        direction = new Vector3(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y), 10f);
        force = distance * direction * pushForce;
        Debug.DrawLine(startPoint, endPoint);


        trajectory.UpdateDots(ball.Position, force);

    }

    public void OnDragEnd()
    {

        ball.ActivateRb();
        ball.Push(force);
        trajectory.Hide();
        GameManager_Muthu.instance.ballReleasedIndicationEvent.Invoke();

        isBallready = false;

    }

    public void ResetBall()
    {
        ball.DeActivateRb();
        ball.transform.position = ball.startPos;
    }
}
