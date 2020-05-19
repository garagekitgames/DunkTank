using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Level", menuName = "ScriptableObjects/Enemies List", order = 4)]
public class EnemyList : ScriptableObject
{
    public List<EnemyInfo> _listOfEnemies = new List<EnemyInfo>();
    public List<EnemyInfo> _listOfBoss = new List<EnemyInfo>();
}
