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

    public bool skipPanel;

    ClickToContinue skip;
    public bool isSkipping;

    [SerializeField] float lerpSpeed;
    [SerializeField] float lerpSpeedFast;
    [SerializeField] float timeWindow;
    [SerializeField] float timeWindowFast;

    [HideInInspector] public int i;
    [HideInInspector] public int[] y;
    [HideInInspector] public int[] x;
    private void Awake()
    {
        FindObjectOfType<ClickToContinue>().isFade = this;
        skip = FindObjectOfType<ClickToContinue>();
        if (fadeIn)
        {
            FindObjectOfType<ClickToContinue>().isFadein = this;
            FindObjectOfType<ClickToContinue>().waitSkip = true;
        }
        else if (fadeOut)
        {
            FindObjectOfType<ClickToContinue>().waitSkip = false;
        }
        if (fadeIn && change)
        {
            TextChange(true);

            if (!changeBoth)
            {
                if (changeBG)
                {
                    i = FindObjectOfType<CommandBehaviours>().fadeBG;
                }
                else
                {
                    y = FindObjectOfType<CommandBehaviours>().fadeSPR;
                }
            }
            else
            {
                x = FindObjectOfType<CommandBehaviours>().fadeBoth;
            }
        }
        panel = GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        isSkipping = skip.skip;
        if (fadeIn)
        {
            if (panel.alpha == 1)
            {
                //do something...
                FindObjectOfType<ClickToContinue>().isFadein = null;
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
            else if (panel.alpha < 0 + timeWindow + timeWindowFast)
            {
                panel.alpha = Mathf.Lerp(panel.alpha, 1, lerpSpeedFast * Time.deltaTime);
            }
            else
            {
                panel.alpha = Mathf.Lerp(panel.alpha, 1, lerpSpeed * Time.deltaTime);
            }
        }
        else if (fadeOut)
        {
            if (!isSkipping)
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
                else if (panel.alpha < 0 + timeWindow + timeWindowFast)
                {
                    panel.alpha = Mathf.Lerp(panel.alpha, 0, lerpSpeedFast * Time.deltaTime);
                }
                else
                {
                    panel.alpha = Mathf.Lerp(panel.alpha, 0, lerpSpeed * Time.deltaTime);
                }
            }
            else
            {
                if (!skipPanel)
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
                    else if (panel.alpha < 0 + timeWindow + timeWindowFast)
                    {
                        panel.alpha = Mathf.Lerp(panel.alpha, 0, lerpSpeedFast * Time.deltaTime);
                    }
                    else
                    {
                        panel.alpha = Mathf.Lerp(panel.alpha, 0, lerpSpeed * Time.deltaTime);
                    }
                }
            }
        }
    }
    void Change()
    {
        TextChange(false);

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
            ChangeBoth(x[0], x[1], x[2]);
            Destroy(gameObject);
        }
    }
    void ChangeBG()
    {
        FindObjectOfType<GameAssets>().currentBG.sprite = FindObjectOfType<GameAssets>().backgrounds[i];
    }
    void ChangeSPR()
    {
        FindObjectOfType<GameAssets>().currentSpriteOne.sprite = FindObjectOfType<GameAssets>().npcSrites[y[0]];
        FindObjectOfType<GameAssets>().currentSpriteTwo.sprite = FindObjectOfType<GameAssets>().npcSrites[y[1]];
    }
    void ChangeBoth(int a, int b, int c)
    {
        FindObjectOfType<GameAssets>().currentBG.sprite = FindObjectOfType<GameAssets>().backgrounds[a];
        FindObjectOfType<GameAssets>().currentSpriteOne.sprite = FindObjectOfType<GameAssets>().npcSrites[b];
        FindObjectOfType<GameAssets>().currentSpriteTwo.sprite = FindObjectOfType<GameAssets>().npcSrites[c];
    }
    void TextChange(bool a)
    {
        if (a)
        {
            FindObjectOfType<SetText>().Change(true);

            FindObjectOfType<SetName>().Change(true);
        }
        else
        {
            FindObjectOfType<SetText>().Change(false);

            FindObjectOfType<SetName>().Change(false);
        }
    }
}
