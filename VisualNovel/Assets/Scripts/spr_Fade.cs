using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class spr_Fade : MonoBehaviour
{
    [SerializeField] CanvasGroup fadeSPR;
    [SerializeField] Image colorSPR;

    [SerializeField] float fadeLerpSpeed;
    [SerializeField] float fadeMargen;

    [SerializeField] float colorLerpSpeed;
    [SerializeField] float colorMargen;

    [HideInInspector] public float fadeSPRValue = 1;
    [HideInInspector] public float colorSPRValue = 1;

    [SerializeField] float fade;
    [SerializeField] float color;
    private void FixedUpdate()
    {
        LerpFadeValueSPR();
        LerpColorValueSPR();

        fadeSPR.alpha = fade;
        colorSPR.color = new Color(color, color, color);
    }
    void LerpFadeValueSPR()
    {
        if (fade != fadeSPRValue)
        {
            fade = Mathf.Lerp(fade, fadeSPRValue, fadeLerpSpeed * Time.fixedDeltaTime);

            if (fade > fadeSPRValue)
            {
                if (fade < fadeSPRValue + fadeMargen)
                {
                    fade = fadeSPRValue;
                }
            }
            else
            {
                if (fade > fadeSPRValue - fadeMargen)
                {
                    fade = fadeSPRValue;
                }
            }
        }
    }
    void LerpColorValueSPR()
    {
        if (color != colorSPRValue)
        {
            color = Mathf.Lerp(color, colorSPRValue, colorLerpSpeed * Time.fixedDeltaTime);

            if (color > colorSPRValue)
            {
                if (color < colorSPRValue + colorMargen)
                {
                    color = colorSPRValue;
                }
            }
            else
            {
                if (color > colorSPRValue - colorMargen)
                {
                    color = colorSPRValue;
                }
            }
        }
    }
}
