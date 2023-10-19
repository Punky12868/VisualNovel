using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableButtons : MonoBehaviour
{
    [SerializeField] GameObject skipButton;
    [SerializeField] GameObject autoButton;

    [SerializeField] GameObject skipFeedback;
    public GameObject autoFeedback;

    public UnityEngine.UI.Button normalColor;
    public UnityEngine.UI.Button activatedColor;
    private void Update()
    {
        if (skipFeedback.activeInHierarchy)
        {
            skipButton.GetComponent<UnityEngine.UI.Button>().colors = activatedColor.colors;
            skipButton.GetComponent<TMPro.TMP_Text>().color = activatedColor.colors.normalColor;
        }
        else
        {
            skipButton.GetComponent<UnityEngine.UI.Button>().colors = normalColor.colors;
            skipButton.GetComponent<TMPro.TMP_Text>().color = normalColor.colors.normalColor;
        }

        if (autoFeedback.activeInHierarchy)
        {
            autoButton.GetComponent<UnityEngine.UI.Button>().colors = activatedColor.colors;
            autoButton.GetComponent<TMPro.TMP_Text>().color = activatedColor.colors.normalColor;
        }
        else
        {
            autoButton.GetComponent<UnityEngine.UI.Button>().colors = normalColor.colors;
            autoButton.GetComponent<TMPro.TMP_Text>().color = normalColor.colors.normalColor;
        }
    }
    public void Disable()
    {
        skipButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
        autoButton.GetComponent<UnityEngine.UI.Button>().interactable = false;
    }
    public void Enable()
    {
        skipButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
        autoButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
    }
}
