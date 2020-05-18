﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    public int currentLevel = 0;
    private int currentSegmentCount = 0;

    [SerializeField]
    Vector3 initialSegmentSpawnPoint;

    public int segmentsPerLevel;
    public float distanceBetweenSegments;

    public Segment[] easySegments;
    public Segment[] mediocreSegments;
    public Segment[] hardSegments;

    [SerializeField]
    List<Segment> currentlySpawnedSegments;

    public Segment currentSegmentObj;

    [Header("Events")]
    //public UnityEvent segmentFinished;
    //public UnityEvent levelFinished;
    public UnityEvent levelFailed;



    public UnityEvent OnLevelFinished;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        //levelFailed.AddListener(OnLevelFailed);
        //segmentFinished.AddListener(OnSegmentCompleted);
        //levelFinished.AddListener(OnLevelCompleted);
        PlaceSegments();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaceSegments()
    {
        //Initial Spawn
        GameObject initialSegment = Instantiate(easySegments[0].gameObject, initialSegmentSpawnPoint, Quaternion.identity);
        currentlySpawnedSegments.Add(initialSegment.GetComponent<Segment>());

        for(int i = 1; i < segmentsPerLevel; i++)
        {
            Vector3 newPosition = currentlySpawnedSegments[i - 1].transform.position;
            newPosition.z += distanceBetweenSegments;
            GameObject obj = Instantiate(easySegments[Random.Range(0,easySegments.Length)].gameObject, newPosition, Quaternion.identity);
            currentlySpawnedSegments.Add(obj.GetComponent<Segment>());
        }

        EnableCurrentSegment();
    }


    void EnableCurrentSegment()
    {
        currentSegmentObj = currentlySpawnedSegments[currentSegmentCount];
        Camera cam = Camera.main;
        //cam.transform.position = currentSegmentObj.cameraPosition.position;
        //cam.transform.eulerAngles = currentSegmentObj.cameraPosition.eulerAngles;
        //Spawn Enemies


        EnemyManager.eManager.SpawnEnemies(currentSegmentObj.enemySpawnPoints);
        
        
        //currentSegmentObj.enemies;

    }

    public void OnGotoNextLevelSuccess()
    {
        currentLevel += 1;
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
        
        if(currentSegmentCount < segmentsPerLevel)
        {
            currentSegmentObj = currentlySpawnedSegments[currentSegmentCount];
            EnableCurrentSegment();
        }
        else
        {
            OnLevelFinished.Invoke();
            //OnLevelCompleted();
        }
    }

    public  void RestartLevel()
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
