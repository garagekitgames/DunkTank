using MyCompany.GameFramework.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public GameObject ballPrefab;

    public Transform launchPoint;

    public float speed;

    public ObjectPool op;

    public void Start()
    {
        op = new ObjectPool(ballPrefab,10);
        ballPrefab.GetComponent<PooledItem>().SetPool(op);
    }

    public void Throw(Vector3 _target)
    {       
       // var ball = Instantiate(ballPrefab, launchPoint.position, Quaternion.identity);
        var ball = op.InstantiateFromPool(launchPoint);
        ball.GetComponent<Rigidbody>().AddForce((_target - launchPoint.position).normalized * speed, ForceMode.VelocityChange);
        StartCoroutine(ReturnObjectToPool(ball));
    }

    public void Throw(Vector3 _target, Vector3 origin)
    {
        var ball = Instantiate(ballPrefab, origin, Quaternion.identity);
        ball.GetComponent<Rigidbody>().AddForce((_target - origin).normalized * speed, ForceMode.VelocityChange);
        //Destroy(ball.gameObject, 3);
    }

    public IEnumerator ReturnObjectToPool(GameObject ball)
    {
        yield return new WaitForSeconds(3f);
        op.ReturnToPool(ball);
    }
}
