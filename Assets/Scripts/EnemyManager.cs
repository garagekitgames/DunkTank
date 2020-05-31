using garagekitgames;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using MyCompany.GameFramework.Pooling;
using EZObjectPools;
using SO;
public enum EnemyTypes {Level1, Level2, Level3, Boss1, Boss2, Boss3, Boss4 }

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

    public IntVariable currentLevel;

    private int i;

    public bool useObjectPool = false;

    //public ObjectPool enemyObjectPool;


    EZObjectPool enemyObjectPool = new EZObjectPool();

    public Dictionary<EnemyTypes, EZObjectPool> curObjectPool = new Dictionary<EnemyTypes, EZObjectPool>();
    public List<EZObjectPool> prevObjectPool = new List<EZObjectPool>();

    public void Awake()
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
            if (useObjectPool)
            {
                
                curObjectPool[_enemySpawnPoint[i].enemyType].TryGetNextObject(_enemySpawnPoint[i].transform.position, Quaternion.identity, out temp);
                Debug.Log("Position Y : " + _enemySpawnPoint[i].transform.position.y);
                // enemyObjectPool.TryGetNextObject(_enemySpawnPoint[i].spawnPosition.position, Quaternion.identity, out temp);
            }
            else
            {
                 temp = Instantiate(GetTheEnemy(_enemySpawnPoint[i].enemyType), _enemySpawnPoint[i].transform.position, Quaternion.identity);

            }



            _listOfEnemy.Add(temp);

            //if(!(currentLevel.value%10 == 0))
            //{
                temp.GetComponent<Enemy_Dunk>().OnSpawned();
            //}
            //else
            //{
            //    //Boss
            //    temp.GetComponent<CharacterHealth>().OnSpawned();
            //}
            
        }
    }


    public void SetUpEnemyPools(Dictionary<EnemyTypes,int> enemyTypes)
    {
        foreach (var enemy in enemyTypes)
        {
            EZObjectPool newObjectPool = EZObjectPool.CreateObjectPool(GetTheEnemy(enemy.Key), GetTheEnemy(enemy.Key).name, enemy.Value, true, true, true);
            //EZObjectPool newObjectPool = EZObjectPool.CreateObjectPool(GetTheEnemy(enemy.Key), GetTheEnemy(enemy.Key).name, 2, true, true, true);

            curObjectPool.Add(enemy.Key, newObjectPool);
        }
    }

    public void StopAllEnemies()
    {

        foreach (var item in enemyRuntimeSet.Items)
        {
            if(item.GetComponent<APRController>())
            {
                item.GetComponent<APRController>().StopCharacter();
            }
            
        }
    }

    public void ResumeAllEnemies()
    {
        if (!(currentLevel.value % 10 == 0))
        {
            foreach (var item in enemyRuntimeSet.Items)
            {
                if (item.GetComponent<APRController>())
                {
                    item.GetComponent<APRController>().ResumeCharacter();
                }

            }
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
