﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public GameObject flashHolder;
    public float flashTime;
    public Sprite[] flashSprites;
    public SpriteRenderer[] spriteRenderers;
    // Start is called before the first frame update
    void Start()
    {
        Deactivate();
    }

    public void Activate()
    {
        flashHolder.SetActive(true);
        int flashSpriteIndex = Random.Range(0, flashSprites.Length);
        for(int i = 0; i < spriteRenderers.Length; i++)
        {
            spriteRenderers[i].sprite = flashSprites[i];
        }
        Invoke("Deactivate", flashTime);
    }

    public void Deactivate()
    {
        flashHolder.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
