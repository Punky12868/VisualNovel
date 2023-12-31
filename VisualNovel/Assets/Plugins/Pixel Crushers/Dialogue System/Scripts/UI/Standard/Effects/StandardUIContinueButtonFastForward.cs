// Copyright (c) Pixel Crushers. All rights reserved.

using System;
using UnityEngine;
using Febucci.UI;

namespace PixelCrushers.DialogueSystem
{

    /// <summary>
    /// This script replaces the normal continue button functionality with
    /// a two-stage process. If the typewriter effect is still playing, it
    /// simply stops the effect. Otherwise it sends OnContinue to the UI.
    /// </summary>
    [AddComponentMenu("")] // Use wrapper.
    public class StandardUIContinueButtonFastForward : MonoBehaviour
    {
        GameObject text;

        [Tooltip("Dialogue UI that the continue button affects.")]
        public StandardDialogueUI dialogueUI;

        [Tooltip("Typewriter effect to fast forward if it's not done playing.")]
        //public AbstractTypewriterEffect typewriterEffect;
        public TypewriterByCharacter typewriterEffect;

#if USE_STM
        [Tooltip("If using SuperTextMesh, assign this instead of typewriter effect.")]
        public SuperTextMesh superTextMesh;
#endif

        [Tooltip("Hide the continue button when continuing.")]
        public bool hideContinueButtonOnContinue = false;

        [Tooltip("If subtitle is displaying, continue past it.")]
        public bool continueSubtitlePanel = true;

        [Tooltip("If alert is displaying, continue past it.")]
        public bool continueAlertPanel = true;

        protected UnityEngine.UI.Button continueButton;

        protected AbstractDialogueUI m_runtimeDialogueUI;
        protected virtual AbstractDialogueUI runtimeDialogueUI
        {
            get
            {
                if (m_runtimeDialogueUI == null)
                {
                    m_runtimeDialogueUI = dialogueUI;
                    if (m_runtimeDialogueUI == null)
                    {
                        m_runtimeDialogueUI = GetComponentInParent<AbstractDialogueUI>();
                        if (m_runtimeDialogueUI == null)
                        {
                            m_runtimeDialogueUI = DialogueManager.dialogueUI as AbstractDialogueUI;
                        }
                    }
                }
                return m_runtimeDialogueUI;
            }
        }

        public virtual void Awake()
        {
            if (typewriterEffect == null)
            {
                typewriterEffect = GetComponentInChildren<TypewriterByCharacter>();
            }
            continueButton = GetComponent<UnityEngine.UI.Button>();
        }

        public virtual void OnFastForward()
        {
            if ((typewriterEffect != null) && typewriterEffect.isShowingText)
            {
                typewriterEffect.SkipTypewriter();
            }
#if USE_STM
            else if (superTextMesh != null && superTextMesh.reading)
            {
                superTextMesh.SkipToEnd();
            }
#endif
            else
            {
                if (hideContinueButtonOnContinue && continueButton != null) continueButton.gameObject.SetActive(false);
                if (runtimeDialogueUI != null)
                {
                    if (continueSubtitlePanel && continueAlertPanel)
                    {
                        StopCoroutine(FindObjectOfType<TextAnimatorSubtitlePanel>().Delay());
                        runtimeDialogueUI.OnContinue();
                        //Debug.Log("continueSubtitlePanel && continueAlertPanel");
                    }
                    else if (continueSubtitlePanel)
                    {
                        runtimeDialogueUI.OnContinueConversation();
                        //Debug.Log("continueSubtitlePanel");
                    }
                    else if (continueAlertPanel)
                    {
                        runtimeDialogueUI.OnContinueAlert();
                        //Debug.Log("continueAlertPanel");
                    }
                }
            }

        }
    }
}
