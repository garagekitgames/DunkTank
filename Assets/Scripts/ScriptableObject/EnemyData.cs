using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Level", menuName = "ScriptableObjects/Enemy Data", order = 6)]
public class EnemyData : ScriptableObject
{   
    public EnemyTypes enemyType;
    public Sprite thumbnail;
    public GameObject enemyPrefab;
}
