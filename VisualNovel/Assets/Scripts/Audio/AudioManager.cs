using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    GameAssets assets;
    AudioClip currentBGM;
    AudioClip currentSpriteBGM;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource spr_bgm;
    [SerializeField] AudioSource sfx;

    bool changeBGM;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioManager");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        assets = FindObjectOfType<GameAssets>();

        /*bgm.clip = assets.BGM[0];
        bgm.Play();*/
    }
    private void Update()
    {
        if (changeBGM)
        {
            
        }
    }
    public void PlaySoundFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
    public void ChangeMusic(AudioClip clip)
    {
        /*currentBGM = clip;
        changeBGM = true;*/
        if (bgm.isPlaying)
        {
            bgm.Stop();
        }
        bgm.clip = clip;
        bgm.Play();
    }
}