using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Level", menuName = "ScriptableObjects/Level Info", order = 2)]
public class LevelInfo : ScriptableObject
{
    public string LevelName;
    public int level;
    
}
