using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Ball", menuName = "ScriptableObjects/Ball Data", order = 5)]
public class BallData : ScriptableObject
{
    public Sprite thumbnail;
    public GameObject ballPrefab;
}
