using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosePanel : MonoBehaviour
{
    [SerializeField] Transform panel;

    Vector2 openSize;
    Vector2 closeSize = new Vector2(0, 0);

    [SerializeField] float lerpSpeed;
    [SerializeField] float margen;

    bool active;
    bool open;
    bool close;
    private void Awake()
    {
        openSize = panel.localScale;
        panel.localScale = closeSize;
    }
    private void FixedUpdate()
    {
        if (active)
        {
            if (open)
            {
                if (panel.localScale.x > openSize.x - margen && panel.localScale.x < openSize.x + margen)
                {
                    panel.localScale = openSize;
                    active = false;
                    open = false;
                }
                else
                {
                    panel.localScale = Vector3.Lerp(panel.localScale, openSize, lerpSpeed * Time.fixedDeltaTime);
                }
            }
            else if (close)
            {
                if (panel.localScale.x > closeSize.x - margen && panel.localScale.x < closeSize.x + margen)
                {
                    panel.localScale = closeSize;
                    active = false;
                    close = false;

                    if (panel.gameObject.activeInHierarchy)
                    {
                        panel.gameObject.SetActive(false);
                    }
                }
                else
                {
                    panel.localScale = Vector3.Lerp(panel.localScale, closeSize, lerpSpeed * Time.fixedDeltaTime);
                }
            }
        }
    }
    public void PanelController(bool i)
    {
        if (i)
        {
            if (!panel.gameObject.activeInHierarchy)
            {
                panel.gameObject.SetActive(true);
            }

            active = true;
            open = true;
            close = false;
        }
        else
        {
            active = true;
            open = false;
            close = true;
        }
    }
}
