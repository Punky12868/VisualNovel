using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
//using UnityEngine.EventSystems;
using UnityEngine;

public class ClickToContinue : MonoBehaviour
{
    [HideInInspector] public PanelFade isFade;
    [HideInInspector] public PanelFade isFadein;
	[SerializeField] float cooldownTime;
    float storedTime;
    bool cooldown;

    bool wait;
    public bool skip;
    [HideInInspector] public bool auto;
    [HideInInspector] public bool canAuto;

    bool skipCool;
    public bool waitSkip;
    [SerializeField] float skipCooldown;
    float skipStoredCooldown;

    [HideInInspector] public bool autoCooldown;
    [SerializeField] float autoCooldownShort;
    [SerializeField] float autoCooldownLong;
    float storedShortAuto;
    float storedLongAuto;

    [HideInInspector] public int textLenght;

    [HideInInspector] public bool onButton;

    public bool stopSkip;
    private void Awake()
    {
        storedTime = cooldownTime;
        storedShortAuto = autoCooldownShort;
        storedLongAuto = autoCooldownLong;
        skipStoredCooldown = skipCooldown;
    }
    private void Update()
    {
        if (stopSkip && skip)
        {
            skip = false;
            stopSkip = false;
        }
        if (isFade != null)
        {
            wait = true;
        }
        else
        {
            wait = false;
            
        }

        if (isFadein == null)
        {
            Skip();
        }
    }
    private void FixedUpdate()
    {
        if (skipCool)
        {
            if (skipCooldown > 0)
            {
                skipCooldown -= Time.fixedDeltaTime;
            }
            else
            {
                skipCool = false;
                skipCooldown = skipStoredCooldown;
            }
        }

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

        if (autoCooldown)
        {
            if (textLenght > 100)
            {
                if (autoCooldownLong > 0)
                {
                    autoCooldownLong -= Time.fixedDeltaTime;
                }
                else
                {
                    FindObjectOfType<StandardUIContinueButtonFastForward>().OnFastForward();
                    autoCooldown = false;
                    autoCooldownLong = storedLongAuto;
                }
            }
            else if (textLenght <= 100)
            {
                if (autoCooldownShort > 0)
                {
                    autoCooldownShort -= Time.fixedDeltaTime;
                }
                else
                {
                    FindObjectOfType<StandardUIContinueButtonFastForward>().OnFastForward();
                    autoCooldown = false;
                    autoCooldownShort = storedShortAuto;
                }
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

                    if (auto)
                    {
                        auto = false;
                        autoCooldown = false;
                    }
                }
            }
        }
    }
    void Skip()
    {
        if (skip)
        {
            if (!skipCool)
            {
                if (!waitSkip)
                {
                    FindObjectOfType<StandardUIContinueButtonFastForward>().OnFastForward();
                    skipCool = true;
                }
            }
        }
    }
    public void Auto()
    {
        if (auto)
        {
            autoCooldown = true;
            autoCooldownLong = storedLongAuto;
            autoCooldownShort = storedShortAuto;
        }
    }
    public void OnAuto(bool a)
    {
        auto = a;
        Debug.Log("auto activated");
    }
    public void OnAutoAfterTextShown(bool a)
    {
        if (canAuto)
        {
            if (!FindObjectOfType<SetText>().stopAuto)
            {
                auto = a;
                autoCooldown = true;
                autoCooldownLong = 0;
                autoCooldownShort = 0;
                Debug.Log("auto force activated");
            }
        }
        else
        {
            if (!FindObjectOfType<SetText>().stopAuto)
            {
                auto = a;
                Debug.Log("auto force activated but option is on screen");
            }
        }
    }
}

