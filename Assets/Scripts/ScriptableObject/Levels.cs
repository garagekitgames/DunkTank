using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Level", menuName = "ScriptableObjects/Level", order = 2)]
public class Levels : ScriptableObject
{
    // public float damage;
    //  public int ammo;

    public string LevelName;
    public int level;
    public Sprite thumbnail;
}
