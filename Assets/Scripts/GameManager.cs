﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton
{

    [Header("Scritable Objects")]
    public Balls currentBall;
    public Levels currentLevel;

    [Header("Variables")]
    public int coinsWonInThisRound;
    public int currentCoins;



    public void EnemyHurt()
    {

    }

    public void EnemyDown()
    {

    }

    public void LevelWon()
    {

    }

    public void LevelLost()
    {

    }

    public void PlayerMisses()
    {

    }

    public void PlayerHit()
    {

    }
}