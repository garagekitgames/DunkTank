using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Level", menuName = "ScriptableObjects/Enemy", order = 3)]
public class EnemyScriptableObject : ScriptableObject
{
   
    public EnemyTypes enemyType;
    public string enemyName;
    public int level;
    public Sprite thumbnail;
    public int hp;
    public GameObject enemyPrefab;
}
