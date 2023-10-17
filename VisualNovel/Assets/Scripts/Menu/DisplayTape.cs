using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTape : MonoBehaviour
{
    [SerializeField] Transform vhs;

    [SerializeField] GameObject playPanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject extrasPanel;

    [SerializeField] Transform opened;
    [SerializeField] Transform closed;
    [SerializeField] Transform changing;

    [SerializeField] float lerpSpeed;
    [SerializeField] float changeLerpSpeed;
    [SerializeField] float margen;

    int buttonIndex;
    int lastButtonPressedIndex;

    bool change;
    bool open;
    bool close;

    bool direction;

    bool play;
    bool options;
    bool extras;
    private void Awake()
    {
        vhs.position = closed.position;
        close = true;
    }
    private void FixedUpdate()
    {
        Lerping();
    }
    public void GetType(string type)
    {
        switch (type)
        {
            case "PlayButton":

                play = true;
                options = false;
                extras = false;

                break;

            case "OptionsButton":

                play = false;
                options = true;
                extras = false;

                break;

            case "ExtrasButton":

                play = false;
                options = false;
                extras = true;

                break;

            default:
                break;
        }
    }
    public void OnClick(int i)
    {
        buttonIndex = i;

        if (open)
        {
            if (buttonIndex == lastButtonPressedIndex)
            {
                change = false;
                open = false;
                close = true;
            }
            else
            {
                change = true;
                direction = true;

                open = true;
                close = false;
                lastButtonPressedIndex = buttonIndex;
            }
        }
        else if (close)
        {
            open = true;
            close = false;
            lastButtonPressedIndex = buttonIndex;
        }
    }
    void GetConditions(bool i)
    {
        if (i)
        {
            if (play)
            {
                playPanel.SetActive(true);

                optionsPanel.SetActive(false);
                extrasPanel.SetActive(false);
            }
            else if (options)
            {
                optionsPanel.SetActive(true);

                playPanel.SetActive(false);
                extrasPanel.SetActive(false);
            }
            else if (extras)
            {
                extrasPanel.SetActive(true);

                playPanel.SetActive(false);
                optionsPanel.SetActive(false);
            }
        }
        else
        {
            if (playPanel.activeInHierarchy || optionsPanel.activeInHierarchy || extrasPanel.activeInHierarchy)
            {
                playPanel.SetActive(false);
                optionsPanel.SetActive(false);
                extrasPanel.SetActive(false);
            }
        }
    }
    void Lerping()
    {
        if (change)
        {
            if (direction)
            {
                if (vhs.position.x > changing.position.x - margen && vhs.position.x < changing.position.x + margen)
                {
                    vhs.position = changing.position;
                    GetConditions(true);
                    direction = false;
                }
                else
                {
                    vhs.position = Vector3.Lerp(vhs.position, changing.position, changeLerpSpeed * Time.fixedDeltaTime);
                }
            }
            else
            {
                if (vhs.position.x > opened.position.x - margen && vhs.position.x < opened.position.x + margen)
                {
                    vhs.position = opened.position;
                    //alreadyOpen = false;
                }
                else
                {
                    vhs.position = Vector3.Lerp(vhs.position, opened.position, lerpSpeed * Time.fixedDeltaTime);
                }
            }
        }
        else if (open)
        {
            if (vhs.position.x > opened.position.x - margen && vhs.position.x < opened.position.x + margen)
            {
                vhs.position = opened.position;
                //open = false;
            }
            else
            {
                vhs.position = Vector3.Lerp(vhs.position, opened.position, lerpSpeed * Time.fixedDeltaTime);

                GetConditions(true);
            }
        }
        else if (close)
        {
            if (vhs.position.x > closed.position.x - margen && vhs.position.x < closed.position.x + margen)
            {
                vhs.position = closed.position;
                GetConditions(false);
                //close = false;
            }
            else
            {
                vhs.position = Vector3.Lerp(vhs.position, closed.position, lerpSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
