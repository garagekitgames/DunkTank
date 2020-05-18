using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Level", menuName = "ScriptableObjects/Enemies List", order = 4)]
public class EnemyList : ScriptableObject
{
    public List<EnemyScriptableObject> _listOfEnemies = new List<EnemyScriptableObject>();
    public List<EnemyScriptableObject> _listOfBoss = new List<EnemyScriptableObject>();
}
