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
    private void Awake()
    {
        if (fadeIn && change)
        {
            i = FindObjectOfType<CommandBehaviours>().Fade();
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
                        if (changeBG)
                        {
                            FindObjectOfType<GameAssets>().currentBG.sprite = FindObjectOfType<GameAssets>().backgrounds[i];
                            Debug.Log("AAAA");
                            Destroy(gameObject);
                        }
                        else if (changeSPR)
                        {
                            FindObjectOfType<GameAssets>().currentSprite.sprite = FindObjectOfType<GameAssets>().npcSrites[i];
                            Debug.Log("BBBB");
                            Destroy(gameObject);
                        }
                        else if (changeBoth)
                        {
                            FindObjectOfType<GameAssets>().currentBG.sprite = FindObjectOfType<GameAssets>().backgrounds[i];
                            FindObjectOfType<GameAssets>().currentSprite.sprite = FindObjectOfType<GameAssets>().npcSrites[i];
                            Debug.Log("CCCC");
                            Destroy(gameObject);
                        }
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
}
