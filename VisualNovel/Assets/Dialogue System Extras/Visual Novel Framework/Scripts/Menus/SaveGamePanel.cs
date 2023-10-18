// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem.VisualNovelFramework
{

    /// <summary>
    /// This script handles the SaveGamePanel.
    /// </summary>
    public class SaveGamePanel : MonoBehaviour
    {

        [Tooltip("Game slots.")]
        public UnityEngine.UI.Button[] slots;

        [Tooltip("Panel to show to confirm player wants to overwrite a saved game.")]
        public GameObject confirmOverwritePanel;

        public SaveHelper m_saveHelper;
        private int m_currentSlotNum = -1;

        private void Awake()
        {
            if (m_saveHelper == null) m_saveHelper = FindObjectOfType<QuickSaveAndLoad>().gameObject.GetComponent<SaveHelper>();
            //CheckSavedGames();
        }

        public void SetupPanel()
        {
            for (int slotNum = 0; slotNum < slots.Length; slotNum++)
            {
                var slot = slots[slotNum];
                var slotLabel = slot.GetComponentInChildren<UnityEngine.UI.Text>();
                if (slotLabel != null) slotLabel.text = m_saveHelper.GetSlotSummary(slotNum);
#if TMP_PRESENT
                var tmpLabel = slot.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                if (tmpLabel != null) tmpLabel.text = m_saveHelper.GetSlotSummary(slotNum);
#endif
            }
        }

        public void SelectSlot(int slotNum)
        {
            m_currentSlotNum = slotNum;
            if (m_saveHelper.IsGameSavedInSlot(slotNum))
            {
                confirmOverwritePanel.SetActive(true);
            }
            else
            {
                //ConfirmSave();
                FindObjectOfType<QuickSaveAndLoad>().SelectSaveSlot(slotNum);
            }
        }

        public void ConfirmSave()
        {
            FindObjectOfType<QuickSaveAndLoad>().SelectSaveSlot(m_currentSlotNum);
            /*m_saveHelper.SaveGame(m_currentSlotNum);
            GetComponent<UIPanel>().Close();*/
        }

        public void CheckSavedGames()
        {
            for (int slotNum = 0; slotNum < slots.Length; slotNum++)
            {
                if (!m_saveHelper.IsGameSavedInSlot(slotNum + 1))
                {
                    var buttonImage = FindObjectOfType<TakeAndDisplayScreenshot>().photoDisplay[slotNum];

                    if (buttonImage != FindObjectOfType<TakeAndDisplayScreenshot>().nullSprite)
                    {
                        buttonImage.sprite = FindObjectOfType<TakeAndDisplayScreenshot>().nullSprite;
                        Debug.Log("EEEEEEEEEEE");
                    }
                }
                else
                {
                    FindObjectOfType<TakeAndDisplayScreenshot>().LoadPhoto();
                }
            }
        }
    }

}