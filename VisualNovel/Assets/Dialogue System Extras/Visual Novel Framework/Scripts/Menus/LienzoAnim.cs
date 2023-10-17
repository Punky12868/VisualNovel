using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LienzoAnim : MonoBehaviour
{
    [SerializeField] Transform lienzo;

    [SerializeField] Transform openedPos;
    [SerializeField] Transform closedPos;

    [SerializeField] float lerpSpeed;
    [SerializeField] float margen;

    [SerializeField] float colorLerp;

    [SerializeField] GameObject loadPanel;
    [SerializeField] GameObject galleryPanel;

    [SerializeField] CanvasGroup focusFade;

    [SerializeField] Button[] deactivateButtons;

    bool active;
    bool open;
    bool close;

    bool fade;
    private void Awake()
    {
        focusFade.alpha = 0f;
        lienzo.position = closedPos.position;
        lienzo.rotation = closedPos.rotation;
    }
    private void FixedUpdate()
    {
        if (active)
        {
            Lerping();
        }

        if (fade)
        {
            if (focusFade.alpha != 0)
            {
                focusFade.alpha = Mathf.Lerp(focusFade.alpha, 0f, colorLerp);
            }
        }
    }
    void Lerping()
    {
        if (open)
        {
            if (focusFade.alpha != 0.5f)
            {
                focusFade.alpha = Mathf.Lerp(focusFade.alpha, 0.5f, colorLerp);
            }

            if (lienzo.position.y > openedPos.position.y - margen && lienzo.position.y < openedPos.position.y + margen)
            {
                lienzo.position = openedPos.position;
                lienzo.rotation = openedPos.rotation;

                focusFade.alpha = 0.5f;

                active = false;
                open = false;
            }
            else
            {
                lienzo.position = Vector3.Lerp(lienzo.position, openedPos.position, lerpSpeed * Time.fixedDeltaTime);
                lienzo.rotation = Quaternion.Slerp(lienzo.rotation, openedPos.rotation, lerpSpeed * Time.fixedDeltaTime);
            }
        }
        else if (close)
        {
            if (!fade)
            {
                fade = true;
            }

            if (lienzo.position.y > closedPos.position.y - margen && lienzo.position.y < closedPos.position.y + margen)
            {
                lienzo.position = closedPos.position;
                lienzo.rotation = closedPos.rotation;

                focusFade.alpha = 0f;

                fade = false;

                if (loadPanel.activeInHierarchy || galleryPanel.activeInHierarchy)
                {
                    loadPanel.SetActive(false);
                    galleryPanel.SetActive(false);
                }

                active = false;
                close = false;
            }
            else
            {
                lienzo.position = Vector3.Lerp(lienzo.position, closedPos.position, lerpSpeed * Time.fixedDeltaTime);
                lienzo.rotation = Quaternion.Slerp(lienzo.rotation, closedPos.rotation, lerpSpeed * Time.fixedDeltaTime);
            }
        }
    }
    public void GetType(string type)
    {
        switch (type)
        {
            case "LoadButton":

                loadPanel.SetActive(true);

                break;

            case "GalleryButton":

                galleryPanel.SetActive(true);

                break;

            default:
                break;
        }
    }
    public void OpenCanvas(bool x)
    {
        if (x)
        {
            for (int i = 0; i < deactivateButtons.Length; i++)
            {
                deactivateButtons[i].interactable = false;
            }

            active = true;
            open = true;
            close = false;
        }
        else
        {
            for (int i = 0; i < deactivateButtons.Length; i++)
            {
                deactivateButtons[i].interactable = true;
            }

            active = true;
            open = false;
            close = true;
        }
    }
}
