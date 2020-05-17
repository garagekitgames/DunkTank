using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Ball", menuName = "ScriptableObjects/Ball", order = 1)]
public class Balls : ScriptableObject
{
    public float damage;
    public int ammo;
    public int unLockBallAtLevel;
    public int ballLevel;
    public int ballMaxLevel;
    public int coinsToBuyBall;
    public Sprite thumbnail;
    public GameObject ballPrefab;

}
