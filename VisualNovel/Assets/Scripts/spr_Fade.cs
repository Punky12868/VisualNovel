using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spr_Fade : MonoBehaviour
{
    [SerializeField] CanvasGroup fadeController;

    [SerializeField] float fade_lerpSpeed;
    [SerializeField] float color_lerpSpeed;

    [SerializeField] float margen;

    float colorIndex;

    [HideInInspector] public bool fadeIn_fade;
    [HideInInspector] public bool fadeIn_color;
    [SerializeField] GameObject spr;
    private void Update()
    {
        FadeLerp();
        ColorLerp();
        spr.GetComponent<Image>().color = new Color32((byte)colorIndex, (byte)colorIndex, (byte)colorIndex, 255);
    }
    void FadeLerp()
    {
        if (fadeIn_fade)
        {
            if (fadeController.alpha > 1 - margen)
            {
                fadeController.alpha = 1;
            }
            else if (fadeController.alpha != 1)
            {
                fadeController.alpha = Mathf.Lerp(fadeController.alpha, 1, fade_lerpSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (fadeController.alpha < 0 + margen)
            {
                fadeController.alpha = 0;
            }
            else if (fadeController.alpha != 0)
            {
                fadeController.alpha = Mathf.Lerp(fadeController.alpha, 0, fade_lerpSpeed * Time.deltaTime);
            }
        }
    }
    void ColorLerp()
    {
        if (fadeIn_color)
        {
            if (colorIndex > 255 - margen)
            {
                colorIndex = 255;
            }
            else if (colorIndex != 255)
            {
                colorIndex = Mathf.Lerp(colorIndex, 255, color_lerpSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (colorIndex < 0 + margen)
            {
                colorIndex = 0;
            }
            else if (colorIndex != 0)
            {
                colorIndex = Mathf.Lerp(colorIndex, 0, color_lerpSpeed * Time.deltaTime);
            }
        }
    }
}
