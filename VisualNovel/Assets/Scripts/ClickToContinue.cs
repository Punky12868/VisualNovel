using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class ClickToContinue : MonoBehaviour
{
    [HideInInspector] public PanelFade isFade;
	[SerializeField] KeyCode continueKey;
	[SerializeField] float cooldownTime;
    float storedTime;
    bool wait;
    bool cooldown;
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

        if (!cooldown)
        {
            if (!wait)
            {
                if (Input.GetKeyDown(continueKey))
                {
                    FindObjectOfType<StandardUIContinueButtonFastForward>().OnFastForward();
                    cooldown = true;
                    //Debug.Log("Continued Key Pressed");
                }
            }
            
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
}
