using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowInput : MonoBehaviour
{
    public bool isBallready;
    public bool isDragging;
    public BallSling ball;
    [SerializeField] private readonly float pushForce = 4f;

    private Vector3 startPoint, endPoint, force, direction;

    public Vector3 minPower, maxPower;
    private float distance;

    public bool touchInput;
    public LayerMask layer;
    
    public Vector3 target;
    public Thrower thrower;
    private Vector3 temOrigin;

    public GameObject targetMarker;
    public enum ThrowType
    {
        FromObject,
        FromScreen
    }

    public ThrowType throwType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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


        HandleInput();
        HandleOutput();

        targetMarker.transform.position = target;
    }


    private void HandleInput()
    {
        if (touchInput)
        {
            Touch[] myTouches = Input.touches;
            if (Input.touchCount == 1)
            {
                //for (int i = 0; i < Input.touchCount; i++)
                //{
                if (myTouches[0].phase == TouchPhase.Stationary || myTouches[0].phase == TouchPhase.Moved)
                {
                    Ray mouseRay = GenerateMouseRay();
                    //RaycastHit hit;

                    //if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit, 100, layer))
                    //{
                    //    // GameObject temp = Instantiate(target, hit.point, Quaternion.identity);
                    //    //Debug.DrawRay(mouseRay.origin, mouseRay.direction * hit.distance, Color.yellow);
                    //    //target = hit.point;
                    //    target = mouseRay.GetPoint(20);
                    //}
                    //else
                    //{
                        target = mouseRay.GetPoint(20);
                    //}

                }
                //}
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Ray mouseRay = GenerateMouseRay();
                //RaycastHit hit;
                temOrigin = mouseRay.origin;
                //if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit, 100, layer))
                //{
                //    // GameObject temp = Instantiate(target, hit.point, Quaternion.identity);
                //    Debug.DrawRay(mouseRay.origin, mouseRay.direction * hit.distance, Color.yellow);
                //    //target = hit.point;
                //    target = mouseRay.GetPoint(20);
                //    target.y += 0.5f;
                //}
                //else
                //{
                    //Debug.DrawRay(mouseRay.origin, mouseRay.direction * 10, Color.red);
                    target = mouseRay.GetPoint(20);
                    target.y += 0.5f;
                //}

            }
        }
    }

    private void HandleOutput()
    {

    }
    public void OnDragStart()
    {
        //float x = Input.mousePosition.x;
        //float y = Input.mousePosition.y;
        //float z = 50f;

        //ball.DeActivateRb();
        //startPoint = cam.ScreenToWorldPoint(new Vector3(x, y, z));
        //print(startPoint);
        //trajectory.Show();

        //raycast to the world and find target
    }

    public void OnDrag()
    {
        //float x = Input.mousePosition.x;
        //float y = Input.mousePosition.y;
        //float z = 50f;

        //endPoint = cam.ScreenToWorldPoint(new Vector3(x, y, z));
        //distance = Vector3.Distance(startPoint, endPoint);
        //// direction = (startPoint - endPoint).normalized;

        //direction = new Vector3(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y), 5f);
        //force = distance * direction * pushForce;
        //Debug.DrawLine(startPoint, endPoint);


        //trajectory.UpdateDots(ball.Position, force);
        //thrower.transform.LookAt(-target);

    }

    public void OnDragEnd()
    {

        //ball.ActivateRb();
        //ball.Push(force);
        ////trajectory.Hide();
        //GameManager_Muthu.instance.ballReleasedIndicationEvent.Invoke();

        //isBallready = false;
        switch (throwType)
        {
            case ThrowType.FromObject:
                thrower.Throw(target);
                break;
            case ThrowType.FromScreen:
                thrower.Throw(target, temOrigin);
                break;
            default:
                break;
        }
        

    }

    public void ResetBall()
    {
        //ball.DeActivateRb();
        //ball.transform.position = ball.startPos;
    }

    Ray GenerateMouseRay()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosFarW = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosNearW = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mouseRay = new Ray(mousePosNearW, mousePosFarW - mousePosNearW);

        return mouseRay;



    }

}
