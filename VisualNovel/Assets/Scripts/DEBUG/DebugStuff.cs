using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStuff : MonoBehaviour
{
    [HideInInspector] public GameObject skippingPanel;
    public GameObject settingsPanel;
    public bool isDev;
    private void Update()
    {
        if (isDev)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                FindObjectOfType<SpawnPanelFade>().loadingGameObject.SetActive(false);
                FindObjectOfType<ClickToContinue>().stopSkip = true;
                FindObjectOfType<ClickToContinue>().skip = false;
                FindObjectOfType<SetText>().stopAuto = true;
                FindObjectOfType<ButtonBehaviours>().canSkip = false;
                FindObjectOfType<ClickToContinue>().canAuto = false;
                FindObjectOfType<ClickToContinue>().autoCooldown = false;
                AudioManager.startSkipping = false;
                AudioManager.stopSkipping = true;
                FeedbackContainer.skip = false;
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                FindObjectOfType<ClickToContinue>().stopSkip = false;
                FindObjectOfType<ButtonBehaviours>().canSkip = true;
                FindObjectOfType<ClickToContinue>().canAuto = true;
            }
        }
        

        /*if (skippingPanel != null)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (skippingPanel.GetComponent<CanvasGroup>().alpha != 0)
                {
                    skippingPanel.GetComponent<CanvasGroup>().alpha = 0;
                }
                else
                {
                    skippingPanel.GetComponent<CanvasGroup>().alpha = 0.3f;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (skippingPanel.activeInHierarchy)
                {
                    skippingPanel.SetActive(false);
                }
                else
                {
                    skippingPanel.SetActive(true);
                }
            }
        }*/
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
