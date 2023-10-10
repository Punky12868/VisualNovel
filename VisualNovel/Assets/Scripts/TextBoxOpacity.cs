using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxOpacity : MonoBehaviour
{
    public CanvasGroup opacity;

    [SerializeField] float fadeLerpSpeed;
    [SerializeField] float fadeMargen;

    public float fadeTxtBoxValue = 1;

    public float fade;
    private void FixedUpdate()
    {
        if (opacity != null)
        {
            LerpTxtBoxOpacityValue();

            opacity.alpha = fade;
        }
    }
    void LerpTxtBoxOpacityValue()
    {
        if (fade != fadeTxtBoxValue)
        {
            fade = Mathf.Lerp(fade, fadeTxtBoxValue, fadeLerpSpeed * Time.fixedDeltaTime);

            if (fade > fadeTxtBoxValue)
            {
                if (fade < fadeTxtBoxValue + fadeMargen)
                {
                    fade = fadeTxtBoxValue;
                }
            }
            else
            {
                if (fade > fadeTxtBoxValue - fadeMargen)
                {
                    fade = fadeTxtBoxValue;
                }
            }
        }
    }
}
