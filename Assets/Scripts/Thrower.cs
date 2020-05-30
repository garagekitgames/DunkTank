using MyCompany.GameFramework.Pooling;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZObjectPools;
using EZCameraShake;
using UnityEngine.Events;

public class Thrower : MonoBehaviour
{
    public GameObject ballPrefab;

    public Transform launchPoint;

    public float speed;

    public ObjectPool op;

    EZObjectPool ballObjectPool = new EZObjectPool();

    //public UnityEvent OnLaunchEvent;

    public void Start()
    {
        //op = new ObjectPool(ballPrefab,100);
        //ballPrefab.GetComponent<PooledItem>().SetPool(op);

        ballObjectPool = EZObjectPool.CreateObjectPool(ballPrefab, ballPrefab.name, 10, true, true, true);
    }

    public void Throw(Vector3 _target)
    {       
       // var ball = Instantiate(ballPrefab, launchPoint.position, Quaternion.identity);
        //var ball = op.InstantiateFromPool(launchPoint);
        //ball.GetComponent<Rigidbody>().AddForce((_target - launchPoint.position).normalized * speed, ForceMode.VelocityChange);

        GameObject ball;
        //Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        ballObjectPool.TryGetNextObject(launchPoint.position, Quaternion.identity, out ball);
        ball.GetComponent<Rigidbody>().AddForce((_target - launchPoint.position).normalized * speed, ForceMode.VelocityChange);
        CameraShaker.Instance.ShakeOnce(Random.Range(0.3f, 0.8f), 20, 0.05f, 0.4f);
        AudioManager.instance.Play("BallLaunch");
        AudioManager.instance.Play("Woosh");
        StartCoroutine(ReturnObjectToPool(ball));
    }

    public void Throw(Vector3 _target, Vector3 origin)
    {
        GameObject ball;
        //Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        ballObjectPool.TryGetNextObject(launchPoint.position, Quaternion.identity, out ball);
        ball.GetComponent<Rigidbody>().AddForce((_target - origin).normalized * speed, ForceMode.VelocityChange);
        CameraShaker.Instance.ShakeOnce(Random.Range(0.3f, 0.8f), 20, 0.05f, 0.4f);
        AudioManager.instance.Play("BallLaunch");
        AudioManager.instance.Play("Woosh");
        //Destroy(ball.gameObject, 3);
        StartCoroutine(ReturnObjectToPool(ball));
    }

    public IEnumerator ReturnObjectToPool(GameObject ball)
    {        
        yield return new WaitForSeconds(3f);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        //op.ReturnToPool(ball);
        ball.SetActive(false);
    }
}
