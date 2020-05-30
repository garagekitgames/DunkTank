using System.Collections;
using UnityEngine;
using EZCameraShake;
public enum BallReleaseType {Continuous,Interval }
public enum ThrowType
{
    FromObject,
    FromScreen
}
public class ThrowInput : MonoBehaviour
{
    public bool touchInput;
    public LayerMask layer;

    public Vector3 target;
    public Thrower thrower;
    private Vector3 temOrigin;

    public GameObject targetMarker;   

    public ThrowType throwType;
    public BallReleaseType ballReleaseType;
    private bool isReloading;

    public CannonInfo currentBall;
    public int ballReleaseCount;

    private void Update()
    {       
        HandleInput();
        targetMarker.transform.position = target;
    }


    private void HandleInput()
    {
        if (touchInput)
        {
            Touch[] myTouches = Input.touches;
            if (Input.touchCount == 1)
            {
                
                if (myTouches[0].phase == TouchPhase.Stationary || myTouches[0].phase == TouchPhase.Moved)
                {
                    Ray mouseRay = GenerateMouseRay();
                   
                    //target = new Vector3(mouseRay.GetPoint(5).x, mouseRay.GetPoint(5).y - 1, mouseRay.GetPoint(5).z);                

                }
             
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                ReloadingFunction();
            }
        }
    }

    private void ReloadingFunction()
    {
        if (!isReloading)
        {
            isReloading = true;
            Ray mouseRay = GenerateMouseRay();
            temOrigin = mouseRay.origin;
            target = mouseRay.GetPoint(20);
            //target.y += 0.5f;

            if(ballReleaseType==BallReleaseType.Continuous)
            {
                StartCoroutine(OnDragEnd());

            }
            else if (ballReleaseType == BallReleaseType.Interval)
            {
                StartCoroutine(OnIntervalRelease());

            }
        }
    }

 

   


    public IEnumerator OnIntervalRelease()
    {
        ballReleaseCount++;

        switch (throwType)
        {
            case ThrowType.FromObject:
                thrower.Throw(target);
                
                break;
            case ThrowType.FromScreen:
                thrower.Throw(target, temOrigin);
                //CameraShaker.Instance.ShakeOnce(Random.Range(0.4f, 1f), 20, 0.05f, 0.4f);
                break;
            default:
                break;
        }
        if(ballReleaseCount>3)
        {
            yield return new WaitForSeconds(currentBall.reloadingTime+0.3f);
            isReloading = false;
            ballReleaseCount = 0;
        }
        else
        {
            yield return new WaitForSeconds( 0.1f);
            isReloading = false;
        }

    }

    public IEnumerator OnDragEnd()
    {
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
        yield return new WaitForSeconds(currentBall.reloadingTime);
        isReloading = false;
    }

   

    public void SwitchThrowType()
    {
        if (throwType == ThrowType.FromObject)
        {
            throwType = ThrowType.FromScreen;
        }
        else
        {
            throwType = ThrowType.FromObject;
        }
    }

    private Ray GenerateMouseRay()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosFarW = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosNearW = Camera.main.ScreenToWorldPoint(mousePosNear);

        Ray mouseRay = new Ray(mousePosNearW, mousePosFarW - mousePosNearW);

        return mouseRay;
    }

}
