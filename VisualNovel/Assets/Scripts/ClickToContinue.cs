using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
//using UnityEngine.EventSystems;
using UnityEngine;

public class ClickToContinue : MonoBehaviour//, IPointerClickHandler
{
    [HideInInspector] public PanelFade isFade;
	//[SerializeField] KeyCode continueKey;
	[SerializeField] float cooldownTime;
    float storedTime;
    bool wait;
    bool cooldown;

    [HideInInspector] public bool onButton;
    private void Awake()
    {
        storedTime = cooldownTime;
    }
    private void Update()
    {
        if (isFade != null)
        {
            wait = true;
        }
        else
        {
            wait = false;
        }

        
    }
    private void FixedUpdate()
    {
        if (cooldown)
        {
            if (cooldownTime > 0)
            {
                cooldownTime -= Time.fixedDeltaTime;
            }
            else
            {
                cooldown = false;
                cooldownTime = storedTime;
            }
        }
        
    }
    public void OnClick()
    {
        if (!cooldown)
        {
            if (!wait)
            {
                if (!onButton)
                {
                    FindObjectOfType<StandardUIContinueButtonFastForward>().OnFastForward();
                    cooldown = true;
                    Debug.Log("Continued Key Pressed");
                }
            }
        }
    }
    /*public void OnPointerClick(PointerEventData eventData)
    {
        if (!cooldown)
        {
            if (!wait)
            {
                if (!onButton)
                {
                    if (Input.GetKeyDown(continueKey))
                    {
                        FindObjectOfType<StandardUIContinueButtonFastForward>().OnFastForward();
                        cooldown = true;
                        Debug.Log("Continued Key Pressed");
                    }
                }
            }
        }
    }*/
}
