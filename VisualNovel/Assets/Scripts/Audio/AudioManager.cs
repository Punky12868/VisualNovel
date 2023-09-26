using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    GameAssets assets;
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioManager");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        assets = FindObjectOfType<GameAssets>();

        bgm.clip = assets.BGM[0];
        bgm.Play();
    }
    public void PlaySoundFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
    public void ChangeMusic(AudioClip clip)
    {
        bgm.Stop();
        bgm.clip = clip;
        bgm.Play();
    }
}