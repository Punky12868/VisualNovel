﻿// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace PixelCrushers.DialogueSystem.VisualNovelFramework
{

    /// <summary>
    /// This script manages the LoadGamePanel.
    /// </summary>
    public class LoadGamePanel : MonoBehaviour
    {
        public Image[] image;

        [Tooltip("Game slots.")]
        public UnityEngine.UI.Button[] slots;

        [Tooltip("This button loads the game in the currently-selected slot.")]
        public UnityEngine.UI.Button loadButton;

        [Tooltip("This button deletes the game in the currently-selected slot.")]
        public UnityEngine.UI.Button deleteButton;

        [Tooltip("Shows the details of the game saved in the currently-selected slot.")]
        public UITextField details;

        [System.Serializable]
        public class StringEvent : UnityEvent<string> { }

        public StringEvent onSetDetails = new StringEvent();

        public UnityEvent onLoadGame = new UnityEvent();

        [HideInInspector]
        public int currentSlotNum = -1;

        protected SaveHelper m_saveHelper = null;

        protected virtual void Awake()
        {
            if (m_saveHelper == null) m_saveHelper = FindObjectOfType<QuickSaveAndLoad>().gameObject.GetComponent<SaveHelper>();
        }

        public virtual void SetupPanel()
        {
            details.SetActive(false);
            loadButton.interactable = false;
            deleteButton.interactable = false;
            for (int slotNum = 0; slotNum < slots.Length; slotNum++)
            {
                var slot = slots[slotNum];
                var containsSavedGame = m_saveHelper.IsGameSavedInSlot(slotNum);
                var slotLabel = slot.GetComponentInChildren<UnityEngine.UI.Text>();
                if (slotLabel != null) slotLabel.text = m_saveHelper.GetSlotSummary(slotNum);
#if TMP_PRESENT
                var tmpLabel = slot.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                if (tmpLabel != null) tmpLabel.text = m_saveHelper.GetSlotSummary(slotNum);
#endif
                slot.interactable = containsSavedGame;
            }
        }

        public virtual void SelectSlot(int slotNum)
        {
            currentSlotNum = slotNum;
            m_saveHelper.currentSlotNum = slotNum;
            loadButton.interactable = true;
            deleteButton.interactable = true;
            var detailsText = m_saveHelper.GetSlotDetails(slotNum);
            details.text = detailsText;
            details.SetActive(true);
            onSetDetails.Invoke(detailsText);

            Debug.Log(slotNum + "<-- SLOTNUM");
            image[slotNum - 1].sprite = FindObjectOfType<TakeAndDisplayScreenshot>().photoDisplay[slotNum - 1].sprite;
        }

        public virtual void LoadCurrentSlot()
        {
            //m_saveHelper.LoadGame(currentSlotNum);
            FindObjectOfType<QuickSaveAndLoad>().LoadCurrentSlotNowCustom(currentSlotNum);
            onLoadGame.Invoke();
        }

        public virtual void DeleteCurrentSlot()
        {
            m_saveHelper.DeleteSavedGame(currentSlotNum);

            FindObjectOfType<TakeAndDisplayScreenshot>().photoDisplay[currentSlotNum - 1].sprite = FindObjectOfType<TakeAndDisplayScreenshot>().nullSprite;

            FindObjectOfType<TakeAndDisplayScreenshot>().SaveDeletePhotoOnClick();

            //SetupPanel();
        }
        public bool CheckSlot()
        {
            if (m_saveHelper.IsGameSavedInSlot(currentSlotNum))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}