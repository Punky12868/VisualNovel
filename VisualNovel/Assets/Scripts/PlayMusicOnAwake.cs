using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnAwake : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioClip clip;
    private void Awake()
    {
        bgm.clip = clip;
        bgm.Play();
    }
}
