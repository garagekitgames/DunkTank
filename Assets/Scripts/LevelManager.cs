using SO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public IntVariable _currentLevel;
    public int currentLevel = 0;
    private int currentSegmentCount = 0;

    [SerializeField]
    private Vector3 initialSegmentSpawnPoint;

    public int segmentsPerLevel;
    public float distanceBetweenSegments;

    [Header("Segments")]
    public Segment[] firstSet;
    public Segment[] secondSet;
    public Segment[] thirdSet;
    public Segment[] fourthSet;
    public Segment[] fifthSet;
    public Segment[] sixthSet;
    public Segment[] seventhSet;
    public Segment[] eighthSet;
    public Segment[] ninthSet;
    public Segment[] tenthSet;
    public Segment[] finalSet;
    
    public Segment[] easySegments;
    public Segment[] mediocreSegments;
    public Segment[] hardSegments;

    [SerializeField]
    private List<Segment> currentlySpawnedSegments;

    public Segment currentSegmentObj;

    [Header("Events")]
    public UnityEvent levelFailed;
    public UnityEvent OnLevelFinished;
    private Dictionary<EnemyTypes, int> enemyType_Dic =
                       new Dictionary<EnemyTypes, int>();

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        PlaceSegments();
        
       
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void PlaceSegments()
    {

        Segment[] segmentsToSpawn = ChooseSegments(_currentLevel.value);

        //Initial Spawn
        GameObject initialSegment = Instantiate(segmentsToSpawn[0].gameObject, initialSegmentSpawnPoint, Quaternion.identity);
        currentlySpawnedSegments.Add(initialSegment.GetComponent<Segment>());

        for (int i = 1; i < segmentsPerLevel; i++)
        {
            Vector3 newPosition = currentlySpawnedSegments[i - 1].transform.position;
            newPosition.z += distanceBetweenSegments;
            GameObject obj = Instantiate(segmentsToSpawn[Random.Range(0, easySegments.Length)].gameObject, newPosition, Quaternion.identity);
            currentlySpawnedSegments.Add(obj.GetComponent<Segment>());
        }

        GetAllEnemyTypes();
        EnemyManager.eManager.SetUpEnemyPools(enemyType_Dic);

        EnableCurrentSegment();
    }

    Segment[] ChooseSegments(int _levelNum)
    {
        Segment[] segmentToReturn = new Segment[segmentsPerLevel];

        switch (_levelNum)
        {
            case int n when (n <= 10):
                for (int i = 0; i < segmentsPerLevel; i++)
                {
                    segmentToReturn[i] = firstSet[Random.Range(0, firstSet.Length)];
                }
                break;

            case int n when (n <= 20 && n >= 11):
                for (int i = 0; i < segmentsPerLevel; i++)
                {
                    segmentToReturn[i] = secondSet[Random.Range(0, secondSet.Length)];
                }
                break;

            case int n when (n < 30 && n >= 21):
                for (int i = 0; i < segmentsPerLevel; i++)
                {
                    segmentToReturn[i] = thirdSet[Random.Range(0, thirdSet.Length)];
                }
                break;

            default:
                for (int i = 0; i < segmentsPerLevel; i++)
                {
                    segmentToReturn[i] = thirdSet[Random.Range(0, thirdSet.Length)];
                }
                break;
        }

        return segmentToReturn;
    }

    private void EnableCurrentSegment()
    {
        currentSegmentObj = currentlySpawnedSegments[currentSegmentCount];
        Camera cam = Camera.main;
       
        //Spawn Enemies


        EnemyManager.eManager.SpawnEnemies(currentSegmentObj.enemySpawnPoints);


        //currentSegmentObj.enemies;

    }

    public void GetAllEnemyTypes()
    {
        foreach (Segment segment in currentlySpawnedSegments)
        {
            foreach (EnemySpawnPoint spawnPoint in segment.enemySpawnPoints)
            {
                if (enemyType_Dic.ContainsKey(spawnPoint.enemyType))
                {
                    enemyType_Dic[spawnPoint.enemyType] = enemyType_Dic[spawnPoint.enemyType] + 1;
                }
                else
                {
                    enemyType_Dic.Add(spawnPoint.enemyType, 1);
                }
                //get enemy types 

                //  Debug.Log(enemyType_Dic);

            }
        }

      
        foreach (KeyValuePair<EnemyTypes, int> item in enemyType_Dic)
        {
            Debug.Log("key  : " + item.Key + " Value : " + item.Value);
        }

    }

    public void OnGotoNextLevelSuccess()
    {
        //currentLevel += 1;
        _currentLevel.value += 1;
        currentSegmentCount = 0;
        for (int i = 0; i < currentlySpawnedSegments.Count; i++)
        {
            //currentlySpawnedSegments.Remove()
            Destroy(currentlySpawnedSegments[i].gameObject);
        }
        currentlySpawnedSegments.Clear();
        currentSegmentObj = null;

        PlaceSegments();
    }

    public void OnSegmentCompleted()
    {
        currentSegmentCount += 1;

        if (currentSegmentCount < segmentsPerLevel)
        {
            currentSegmentObj = currentlySpawnedSegments[currentSegmentCount];
            EnableCurrentSegment();
        }
        else
        {
            _currentLevel.value += 1;
            OnLevelFinished.Invoke();
            //OnLevelCompleted();
        }
    }

    public void RestartLevel()
    {
        //Show UI.
        //Destroy all enemeies
        Debug.Log("Level Failed");
        EnemyManager.eManager.DisableEnemies();
        for (int i = 0; i < currentlySpawnedSegments.Count; i++)
        {
            Destroy(currentlySpawnedSegments[i].gameObject);
        }
        currentlySpawnedSegments.Clear();

        currentSegmentCount = 0;
        //currentSegmentObj = currentlySpawnedSegments[currentSegmentCount];
        PlaceSegments();
    }

}
