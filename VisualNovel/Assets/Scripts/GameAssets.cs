using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GameAssets : MonoBehaviour
{
    public Image currentBG;
    public Image currentSpriteOne;
    public Image currentSpriteTwo;
    public string currentNpcName;

    public Sprite[] backgrounds;
    public Sprite[] npcSrites;

    public AudioClip[] BGM;
    public AudioClip[] SFX;
    private void Awake()
    {
        currentBG = GameObject.FindGameObjectWithTag("GameObjectBG").GetComponent<Image>();
        currentSpriteOne = GameObject.FindGameObjectWithTag("GameObjectSPR").GetComponent<Image>();
    }
}
