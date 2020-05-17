using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public GameObject ballPrefab;

    public Transform launchPoint;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Throw(Vector3 _target)
    {
        
        var ball = Instantiate(ballPrefab, launchPoint.position, Quaternion.identity);

        ball.GetComponent<Rigidbody>().AddForce((_target - launchPoint.position).normalized * speed, ForceMode.VelocityChange);

        Destroy(ball.gameObject, 3);
    }

    public void Throw(Vector3 _target, Vector3 origin)
    {

        var ball = Instantiate(ballPrefab, origin, Quaternion.identity);

        ball.GetComponent<Rigidbody>().AddForce((_target - origin).normalized * speed, ForceMode.VelocityChange);

        Destroy(ball.gameObject, 3);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
