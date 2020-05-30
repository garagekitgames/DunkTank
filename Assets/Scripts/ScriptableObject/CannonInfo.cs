using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Ball", menuName = "ScriptableObjects/Ball Info", order = 1)]
public class CannonInfo : ScriptableObject
{
    public float damage;
    public int ammo;
    public int unLockBallAtLevel;
    public int ballLevel;
    public int ballMaxLevel;
    public int coinsToBuyBall;
    public float reloadingTime;
    public string ballDataName;
    public bool isUnlocked;
    public int cannonId;
}
