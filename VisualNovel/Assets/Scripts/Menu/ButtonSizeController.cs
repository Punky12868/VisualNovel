using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonSizeController : MonoBehaviour
{
    [SerializeField] Transform buttonNonHighlightParent;
    [SerializeField] Transform buttonHighlightParent;
    Transform button;

    Vector2 normalButtonSize;
    [SerializeField] Vector2 highlightedButtonSize;

    [SerializeField] Transform buttonText;

    [SerializeField] float lerpSpeed;
    [SerializeField] float margen;

    [SerializeField] bool exitButton;
    [HideInInspector] public bool highlighted;
    bool i;
    private void Awake()
    {
        button = gameObject.transform;
        normalButtonSize = button.localScale;
        i = true;
    }
    private void FixedUpdate()
    {
        if (i)
        {
            if (highlighted)
            {
                if (!exitButton)
                {
                    button.SetParent(buttonHighlightParent);
                }

                if (button.localScale.x > highlightedButtonSize.x - margen && button.localScale.x < highlightedButtonSize.x + margen)
                {
                    button.localScale = highlightedButtonSize;
                    buttonText.localScale = highlightedButtonSize;
                }
                else
                {
                    button.localScale = Vector3.Lerp(button.localScale, highlightedButtonSize, lerpSpeed * Time.fixedDeltaTime);
                    buttonText.localScale = Vector3.Lerp(buttonText.localScale, highlightedButtonSize, lerpSpeed * Time.fixedDeltaTime);
                }
            }
            else
            {
                if (!exitButton)
                {
                    button.SetParent(buttonNonHighlightParent);
                }

                if (button.localScale.x > normalButtonSize.x - margen && button.localScale.x < normalButtonSize.x + margen)
                {
                    button.localScale = normalButtonSize;
                    buttonText.localScale = normalButtonSize;
                }
                else
                {
                    button.localScale = Vector3.Lerp(button.localScale, normalButtonSize, lerpSpeed * Time.fixedDeltaTime);
                    buttonText.localScale = Vector3.Lerp(buttonText.localScale, normalButtonSize, lerpSpeed * Time.fixedDeltaTime);
                }
            }
        }
    }
}
