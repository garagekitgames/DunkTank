using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Level", menuName = "ScriptableObjects/Enemy Info", order = 8)]
public class EnemyInfo : ScriptableObject
{
   
    public EnemyTypes enemyType;
    public string enemyDataName;
    public int level;
    public int hp;
}
