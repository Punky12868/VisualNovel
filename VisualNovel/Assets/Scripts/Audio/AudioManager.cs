using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    GameAssets assets;
    public AudioSource bgm;
    public AudioSource spr_bgm;
    [SerializeField] AudioSource sfx;

    private float audioFadeValue;
    private float audioFadeMaxValue;

    public static bool change_bgmToBgm;
    public static bool change_bgmToSpr;
    public static bool change_sprToBgm;

    public static bool skipping;

    public static bool startSkipping;
    public static bool stopSkipping;

    public float audioFadeMultiplier;
    public static bool changeBGM;
    bool changedBGM;

    bool restoredAudioValue;

    public static int song;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioManager");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        assets = FindObjectOfType<GameAssets>();
        audioFadeValue = FindObjectOfType<VolumeSettings>().bgmSlider.value;

        /*bgm.clip = assets.BGM[0];
        bgm.Play();*/
    }
    private void FixedUpdate()
    {
        if (skipping)
        {
            IsSkipping();
        }

        if (change_bgmToBgm)
        {
            BgmToBgm();
        }
        else if (change_bgmToSpr)
        {
            BgmToSpr();
        }
        else if (change_sprToBgm)
        {
            SprToBgm();
        }
    }
    void BgmToBgm()
    {
        if (restoredAudioValue)
        {
            FindObjectOfType<VolumeSettings>().bgmSlider.value = audioFadeValue;
            FindObjectOfType<VolumeSettings>().SetBGMVolume();
        }

        if (changeBGM)
        {
            if (!restoredAudioValue)
            {
                audioFadeMaxValue = FindObjectOfType<VolumeSettings>().bgmSlider.value;
                restoredAudioValue = true;
            }

            if (audioFadeValue > FindObjectOfType<VolumeSettings>().bgmSlider.minValue)
            {
                audioFadeValue -= audioFadeMultiplier * Time.fixedUnscaledDeltaTime;
            }
            else
            {
                audioFadeValue = FindObjectOfType<VolumeSettings>().bgmSlider.minValue;
                bgm.Stop();
                bgm.clip = assets.BGM[song];
                bgm.Play();
                changeBGM = false;
                changedBGM = true;
            }
        }
        else if (changedBGM)
        {
            if (audioFadeValue < audioFadeMaxValue)
            {
                audioFadeValue += audioFadeMultiplier * Time.fixedUnscaledDeltaTime;
            }
            else
            {
                audioFadeValue = audioFadeMaxValue;
                changedBGM = false;
                change_bgmToBgm = false;
                restoredAudioValue = false;
            }
        }
    }
    void BgmToSpr()
    {
        if (restoredAudioValue)
        {
            FindObjectOfType<VolumeSettings>().bgmSlider.value = audioFadeValue;
            FindObjectOfType<VolumeSettings>().SetBGMVolume();
        }

        if (changeBGM)
        {
            if (!restoredAudioValue)
            {
                audioFadeMaxValue = FindObjectOfType<VolumeSettings>().bgmSlider.value;
                restoredAudioValue = true;
            }

            if (audioFadeValue > FindObjectOfType<VolumeSettings>().bgmSlider.minValue)
            {
                audioFadeValue -= audioFadeMultiplier * Time.fixedUnscaledDeltaTime;
            }
            else
            {
                audioFadeValue = FindObjectOfType<VolumeSettings>().bgmSlider.minValue;
                bgm.Pause();
                if (spr_bgm.isPlaying)
                {
                    spr_bgm.Stop();
                }
                spr_bgm.clip = assets.BGM[song];
                spr_bgm.Play();
                changeBGM = false;
                changedBGM = true;
            }
        }
        else if (changedBGM)
        {
            if (audioFadeValue < audioFadeMaxValue)
            {
                audioFadeValue += audioFadeMultiplier * Time.fixedUnscaledDeltaTime;
            }
            else
            {
                audioFadeValue = audioFadeMaxValue;
                changedBGM = false;
                change_bgmToSpr = false;
                restoredAudioValue = false;
            }
        }
    }
    void SprToBgm()
    {
        if (restoredAudioValue)
        {
            FindObjectOfType<VolumeSettings>().bgmSlider.value = audioFadeValue;
            FindObjectOfType<VolumeSettings>().SetBGMVolume();
        }

        if (changeBGM)
        {
            if (!restoredAudioValue)
            {
                audioFadeMaxValue = FindObjectOfType<VolumeSettings>().bgmSlider.value;
                restoredAudioValue = true;
            }

            if (audioFadeValue > FindObjectOfType<VolumeSettings>().bgmSlider.minValue)
            {
                audioFadeValue -= audioFadeMultiplier * Time.fixedUnscaledDeltaTime;
            }
            else
            {
                audioFadeValue = FindObjectOfType<VolumeSettings>().bgmSlider.minValue;
                spr_bgm.Stop();
                bgm.Play();
                changeBGM = false;
                changedBGM = true;
            }
        }
        else if (changedBGM)
        {
            if (audioFadeValue < audioFadeMaxValue)
            {
                audioFadeValue += audioFadeMultiplier * Time.fixedUnscaledDeltaTime;
            }
            else
            {
                audioFadeValue = audioFadeMaxValue;
                changedBGM = false;
                change_sprToBgm = false;
                restoredAudioValue = false;
            }
        }
    }
    void IsSkipping()
    {
        if (restoredAudioValue)
        {
            FindObjectOfType<VolumeSettings>().masterSlider.value = audioFadeValue;
            FindObjectOfType<VolumeSettings>().SetMasterVolume();
        }

        if (startSkipping)
        {
            if (!restoredAudioValue)
            {
                audioFadeMaxValue = FindObjectOfType<VolumeSettings>().masterSlider.value;
                restoredAudioValue = true;
            }

            if (audioFadeValue > FindObjectOfType<VolumeSettings>().masterSlider.minValue)
            {
                audioFadeValue -= audioFadeMultiplier * Time.fixedUnscaledDeltaTime;
            }
            else
            {
                audioFadeValue = FindObjectOfType<VolumeSettings>().masterSlider.minValue;
            }
        }
        else if (stopSkipping)
        {
            if (audioFadeValue < audioFadeMaxValue)
            {
                audioFadeValue += audioFadeMultiplier * Time.fixedUnscaledDeltaTime;
            }
            else
            {
                audioFadeValue = audioFadeMaxValue;
                stopSkipping = false;
                skipping = false;
            }
        }
    }
    public void PlaySoundFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
}