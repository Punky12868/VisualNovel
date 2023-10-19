using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class SpawnPanelFade : MonoBehaviour
{
    public GameObject loadingGameObject;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject spawnPointSkip;
    [SerializeField] GameObject[] panelFades;

    static bool spawnFadeIn;

    static bool spawnFadeInBG;
    static bool spawnFadeInSPR;
    static bool spawnFadeInBoth;

    static bool spawnFadeOut;
    static bool spawnFadeOutSkip;
    /*private void Awake()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("CanvasSpawnPoint");
    }*/
    private void Update()
    {
        if (spawnFadeIn)
        {
            Instantiate(panelFades[0], spawnPoint.transform);
            spawnFadeIn = false;
        }
        else if (spawnFadeInBG)
        {
            Instantiate(panelFades[2], spawnPoint.transform);
            spawnFadeInBG = false;
        }
        else if (spawnFadeInSPR)
        {
            Instantiate(panelFades[3], spawnPoint.transform);
            spawnFadeInSPR = false;
        }
        else if (spawnFadeInBoth)
        {
            Instantiate(panelFades[4], spawnPoint.transform);
            spawnFadeInBoth = false;
        }
        else if (spawnFadeOut)
        {
            Instantiate(panelFades[1], spawnPoint.transform);
            spawnFadeOut = false;
        }
        else if (spawnFadeOutSkip)
        {
            Instantiate(panelFades[5], spawnPointSkip.transform);
            spawnFadeOutSkip = false;
        }
    }
    public static void SpawnFadeInPanelBG()
    {
        spawnFadeInBG = true;
    }
    public static void SpawnFadeInPanelSPR()
    {
        spawnFadeInSPR = true;
    }
    public static void SpawnFadeInPanelBoth()
    {
        spawnFadeInBoth = true;
    }
    public static void SpawnFadeInPanel()
    {
        spawnFadeIn = true;
    }
    public static void SpawnFadeOutPanel()
    {
        spawnFadeOut = true;
    }
    public static void SpawnFadeOutPanelSkip()
    {
        spawnFadeOutSkip = true;
    }
}
