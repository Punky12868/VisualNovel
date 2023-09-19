using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurController : MonoBehaviour
{
    [SerializeField] Material blurBG;
    [SerializeField] Material blurSPR;

    [SerializeField] float lerpSpeed;
    [SerializeField] float margen;

    [Range(0.0f, 3.5f)] public float blurBGValue;
    [Range(0.0f, 3.5f)] public float blurSPRValue;

    [SerializeField] float bg;
    [SerializeField] float spr;
    private void FixedUpdate()
    {
        LerpBlurValueBG();
        LerpBlurValueSPR();

        blurBG.SetFloat("_Size", bg);
        blurSPR.SetFloat("_Size", spr);
    }
    void LerpBlurValueBG()
    {
        if (bg != blurBGValue)
        {
            bg = Mathf.Lerp(bg, blurBGValue, lerpSpeed * Time.fixedDeltaTime);

            if (bg > blurBGValue)
            {
                if (bg < blurBGValue + margen)
                {
                    bg = blurBGValue;
                }
            }
            else
            {
                if (bg > blurBGValue - margen)
                {
                    bg = blurBGValue;
                }
            }
        }
    }
    void LerpBlurValueSPR()
    {
        if (spr != blurSPRValue)
        {
            spr = Mathf.Lerp(spr, blurSPRValue, lerpSpeed * Time.fixedDeltaTime);

            if (spr > blurSPRValue)
            {
                if (spr < blurSPRValue + margen)
                {
                    spr = blurSPRValue;
                }
            }
            else
            {
                if (spr > blurSPRValue - margen)
                {
                    spr = blurSPRValue;
                }
            }
        }
    }
}
