using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using System;

public class GetSliders : MonoBehaviour
{
    VolumeSettings settings;

    [SerializeField] Slider master;
    public Slider bgm;
    [SerializeField] Slider sfx;
    private void Awake()
    {
        settings = FindObjectOfType<VolumeSettings>();

        master.value = settings.masterSlider.value;
        bgm.value = settings.bgmSlider.value;
        sfx.value = settings.sfxSlider.value;
    }
    public void ChangeMaster()
    {
        settings.masterSlider.value = master.value;
        settings.SetMasterVolume();
    }
    public void ChangeBGM()
    {
        settings.bgmSlider.value = bgm.value;
        settings.SetBGMVolume();
    }
    public void ChangeSFX()
    {
        settings.sfxSlider.value = sfx.value;
        settings.SetSFXVolume();
    }
}
