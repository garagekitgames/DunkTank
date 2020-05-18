using garagekitgames;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public enum EnemyTypes {Level1,Level2,Level3 }

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager eManager;

    [Header("Scriptable object")]
    public EnemyRuntimeSet enemyRuntimeSet;
    public EnemyList enemyList;

    [Header("Event")]
    public UnityEvent allEnemiesDead;

    [Header("List")]
    private List<GameObject> _listOfEnemy = new List<GameObject>();
    public List<GameObject> _listOfDiedEnemy = new List<GameObject>();

    private int i;


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
            GameObject temp = Instantiate(GetTheEnemy(_enemySpawnPoint[i].enemyType), _enemySpawnPoint[i].spawnPosition.position, Quaternion.identity);
            //   float x = Random.Range(-5, 5);
            //   float y = Random.Range(-5, 5);
            //temp.transform.position = _enemySpawnPoint[i].spawnPosition.position;
            _listOfEnemy.Add(temp);
            temp.GetComponent<Enemy_Dunk>().OnSpawned();
        }
    }

    GameObject GetTheEnemy(EnemyTypes _reqdType)
    {
        EnemyScriptableObject enemy = enemyList._listOfEnemies.ToList().Where(x => x.enemyType == _reqdType).First();
        return enemy.enemyPrefab;
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
            LevelManager.instance.segmentFinished.Invoke();
        }
    }
   
    #endregion

}
