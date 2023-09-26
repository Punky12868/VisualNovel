using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using System;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;

    [SerializeField] Slider masterSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
    private void Awake()
    {
        masterSlider = GameObject.FindGameObjectWithTag("MasterSlider").GetComponent<Slider>();
        bgmSlider = GameObject.FindGameObjectWithTag("BGMSlider").GetComponent<Slider>();
        sfxSlider = GameObject.FindGameObjectWithTag("SFXSlider").GetComponent<Slider>();

        float masterVolume = masterSlider.value;
        mixer.SetFloat("Master", Mathf.Log10(masterVolume) * 20);

        float bgmVolume = bgmSlider.value;
        mixer.SetFloat("BGM", Mathf.Log10(bgmVolume) * 20);

        float sfxVolume = sfxSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(sfxVolume) * 20);
    }

    private Slider FindGameObjectsWithTag(string v)
    {
        throw new NotImplementedException();
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        mixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    public void SetBGMVolume()
    {
        float volume = bgmSlider.value;
        mixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
}
