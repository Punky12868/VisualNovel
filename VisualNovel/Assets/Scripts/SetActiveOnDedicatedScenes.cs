using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SetActiveOnDedicatedScenes : MonoBehaviour
{
    public int menuScene;
    public int gameplayScene;
    public GameObject[] allGameObjectsActive;
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DestroyAll");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (allGameObjectsActive[allGameObjectsActive.Length - 1].activeInHierarchy && SceneManager.GetActiveScene().buildIndex == menuScene)
        {
            for (int i = 0; i < allGameObjectsActive.Length; i++)
            {
                allGameObjectsActive[i].SetActive(false);
            }
        }
        else if (!allGameObjectsActive[allGameObjectsActive.Length - 1].activeInHierarchy && SceneManager.GetActiveScene().buildIndex == gameplayScene)
        {
            for (int i = 0; i < allGameObjectsActive.Length; i++)
            {
                allGameObjectsActive[i].SetActive(true);
            }
        }
    }
}
