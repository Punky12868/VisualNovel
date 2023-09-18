using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFade : MonoBehaviour
{
    CanvasGroup panel;

    public bool fadeIn;
    public bool fadeOut;

    public bool change;
    public bool changeBG;
    public bool changeSPR;
    public bool changeBoth;

    [SerializeField] float lerpSpeed;
    [SerializeField] float timeWindow;

    [HideInInspector] public int i;
    [HideInInspector] public int[] x = new int[2];
    private void Awake()
    {
        if (fadeIn && change)
        {
            if (!changeBoth)
            {
                if (changeBG)
                {
                    i = FindObjectOfType<CommandBehaviours>().fadeBG;
                }
                else
                {
                    i = FindObjectOfType<CommandBehaviours>().fadeSPR;
                }
            }
            else
            {
                x = FindObjectOfType<CommandBehaviours>().GetFadeBothIDs();
            }
        }
        panel = GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        if (fadeIn)
        {
            if (panel.alpha == 1)
            {
                //do something...
                SpawnPanelFade[] fades = FindObjectsOfType<SpawnPanelFade>();
                if (fades.Length > 0)
                {
                    if (change)
                    {
                        Change();
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
            }
            else if (panel.alpha > 1 - timeWindow)
            {
                SpawnPanelFade.SpawnFadeOutPanel();
                panel.alpha = 1;
            }
            else
            {
                panel.alpha = Mathf.Lerp(panel.alpha, 1, lerpSpeed * Time.deltaTime);
            }
        }
        else if (fadeOut)
        {
            if (panel.alpha == 0)
            {
                Destroy(gameObject);
                fadeOut = false;
            }
            else if (panel.alpha < 0 + timeWindow)
            {
                panel.alpha = 0;
            }
            else
            {
                panel.alpha = Mathf.Lerp(panel.alpha, 0, lerpSpeed * Time.deltaTime);
            }
        }
    }
    void Change()
    {
        if (changeBG)
        {
            ChangeBG();
            Destroy(gameObject);
        }
        else if (changeSPR)
        {
            ChangeSPR();
            Destroy(gameObject);
        }
        else if (changeBoth)
        {
            ChangeBoth(x[0], x[1]);
            Destroy(gameObject);
        }
    }
    void ChangeBG()
    {
        FindObjectOfType<GameAssets>().currentBG.sprite = FindObjectOfType<GameAssets>().backgrounds[i];
    }
    void ChangeSPR()
    {
        FindObjectOfType<GameAssets>().currentSprite.sprite = FindObjectOfType<GameAssets>().npcSrites[i];
    }
    void ChangeBoth(int a, int b)
    {
        FindObjectOfType<GameAssets>().currentBG.sprite = FindObjectOfType<GameAssets>().backgrounds[a];
        FindObjectOfType<GameAssets>().currentSprite.sprite = FindObjectOfType<GameAssets>().npcSrites[b];
    }
}
