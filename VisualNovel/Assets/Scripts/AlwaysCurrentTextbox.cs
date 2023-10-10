using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AlwaysCurrentTextbox : MonoBehaviour
{
    public GameObject opacityController;
    private void Awake()
    {
        if (GetComponent<Image>().sprite != FindObjectOfType<GameAssets>().currentTextbox.sprite)
        {
            GetComponent<Image>().sprite = FindObjectOfType<GameAssets>().currentTextbox.sprite;
        }

        if (opacityController.GetComponent<CanvasGroup>() != FindObjectOfType<TextBoxOpacity>().opacity)
        {
            FindObjectOfType<TextBoxOpacity>().opacity = opacityController.GetComponent<CanvasGroup>();
        }
    }
    private void Update()
    {
        if (GetComponent<Image>().sprite != FindObjectOfType<GameAssets>().currentTextbox.sprite)
        {
            GetComponent<Image>().sprite = FindObjectOfType<GameAssets>().currentTextbox.sprite;
        }
    }
}
