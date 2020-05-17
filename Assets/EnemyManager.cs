using garagekitgames;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager eManager;

    public EnemyRuntimeSet enemyRuntimeSet;
    public UnityEvent allEnemiesDead;
    private List<GameObject> _listOfEnemy = new List<GameObject>();
    public List<GameObject> _listOfDiedEnemy = new List<GameObject>();
    private int i;

    public GameObject enemyPrefab;
    public Transform pos;



    public void Start()
    {
        eManager = GetComponent<EnemyManager>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnEnemies(5f, pos);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _listOfEnemy[0].GetComponent<Enemy_Dunk>().OnDamage(25f);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            enemyRuntimeSet.Items.Clear();
        }
    }

    #region Enemy Spawn Function

    public void SpawnEnemies(float _listOfEnemies, Transform pos)
    {
        for (i = 0; i < _listOfEnemies; i++)
        {
            GameObject temp = Instantiate(enemyPrefab, pos);
            float x = Random.Range(-5, 5);
            float y = Random.Range(-5, 5);
            temp.transform.localPosition = new Vector3(x, y, Random.Range(0, 5));
            _listOfEnemy.Add(temp);
            temp.GetComponent<Enemy_Dunk>().OnSpawned();
        }
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
        }
    }
   
    #endregion

}
