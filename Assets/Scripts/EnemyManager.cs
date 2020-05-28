using garagekitgames;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using MyCompany.GameFramework.Pooling;
using EZObjectPools;
public enum EnemyTypes {Level1,Level2,Level3 }

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager eManager;

    [Header("Scriptable object")]
    public EnemyRuntimeSet enemyRuntimeSet;
    public EnemyList enemyList;

    [Header("Event")]
    public UnityEvent allEnemiesDead;

    public UnityEvent OnSegmentFinished;

    [Header("List")]
    private List<GameObject> _listOfEnemy = new List<GameObject>();
    public List<GameObject> _listOfDiedEnemy = new List<GameObject>();

    private int i;

    //public ObjectPool enemyObjectPool;


    EZObjectPool enemyObjectPool = new EZObjectPool();

    public Dictionary<EnemyTypes, EZObjectPool> curObjectPool = new Dictionary<EnemyTypes, EZObjectPool>();
    public List<EZObjectPool> prevObjectPool = new List<EZObjectPool>();

    public void Start()
    {
        eManager = GetComponent<EnemyManager>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //SpawnEnemies(5f, testPos);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _listOfEnemy[0].GetComponent<Enemy_Dunk>().OnDamage(25f);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            enemyRuntimeSet.Items.Clear();
            CheckAllEnemiesDiedBeforeReaching();
        }
    }

    #region Enemy Spawn Function

    public void SpawnEnemies(EnemySpawnPoint[] _enemySpawnPoint)
    {       

        for (i = 0; i < _enemySpawnPoint.Length; i++)
        {
            GameObject temp;
            curObjectPool[_enemySpawnPoint[i].enemyType].TryGetNextObject(_enemySpawnPoint[i].spawnPosition.position, Quaternion.identity, out temp);
           // enemyObjectPool.TryGetNextObject(_enemySpawnPoint[i].spawnPosition.position, Quaternion.identity, out temp);
            _listOfEnemy.Add(temp);
            temp.GetComponent<Enemy_Dunk>().OnSpawned();
        }
    }


    public void SetUpEnemyPools(Dictionary<EnemyTypes,int> enemyTypes)
    {
        foreach (var enemy in enemyTypes)
        {
            EZObjectPool newObjectPool = EZObjectPool.CreateObjectPool(GetTheEnemy(enemy.Key), GetTheEnemy(enemy.Key).name, enemy.Value / 2, true, true, true);
            //EZObjectPool newObjectPool = EZObjectPool.CreateObjectPool(GetTheEnemy(enemy.Key), GetTheEnemy(enemy.Key).name, 2, true, true, true);

            curObjectPool.Add(enemy.Key, newObjectPool);
        }
    }

    public void StopAllEnemies()
    {
        foreach (var item in enemyRuntimeSet.Items)
        {
            item.GetComponent<APRController>().StopCharacter();
        }
    }

    public void ResumeAllEnemies()
    {
        foreach (var item in enemyRuntimeSet.Items)
        {
            item.GetComponent<APRController>().ResumeCharacter();
        }
    }

    GameObject GetTheEnemy(EnemyTypes _reqdType)
    {
        EnemyInfo enemy = enemyList._listOfEnemies.ToList().Where(x => x.enemyType == _reqdType).First();
        EnemyData tempEnemyData = Resources.Load<EnemyData>("EnemyData/" + enemy.enemyDataName);

        return tempEnemyData.enemyPrefab;
    }

    #endregion

    #region New Segment

    public void OnNewSegmentStarted()
    {
        if (!(enemyRuntimeSet.Items.Count > 0))
        {
            allEnemiesDead.Invoke();
            enemyRuntimeSet.Items.Clear();
        }
    }

    public void CheckAllEnemiesDiedBeforeReaching()
    {
        if (!(enemyRuntimeSet.Items.Count > 0))
        {
            allEnemiesDead.Invoke();
            enemyRuntimeSet.Items.Clear();
            //LevelManager.instance.segmentFinished.Invoke();
            OnSegmentFinished.Invoke();

        }
    }

    public void OnLevelCompleted()
    {
        Debug.Log("Mudinjiduchu");
    }

    public void DisableEnemies()
    {
        for (int i = 0; i < _listOfEnemy.Count; i++)
        {
            _listOfEnemy[i].SetActive(false);
        }
        enemyRuntimeSet.Items.Clear();
    }

    private void OnApplicationQuit()
    {
        enemyRuntimeSet.Items.Clear();
    }

    //public void ReturnToPool(GameObject enemy)
    //{
    //    enemyObjectPool.ReturnToPool(enemy);
    //}

    #endregion

}
