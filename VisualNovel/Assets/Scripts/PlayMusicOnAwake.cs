using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnAwake : MonoBehaviour
{
    [SerializeField] int clip;
    private void Awake()
    {
        AudioManager.song = clip;
        AudioManager.change_bgmToBgm = true;
        AudioManager.changeBGM = true;
    }
}
