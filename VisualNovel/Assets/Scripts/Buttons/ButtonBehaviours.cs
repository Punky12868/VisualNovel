using PixelCrushers;
using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviours : MonoBehaviour
{
    [SerializeField] public TMPro.TMP_Text dialogHistory;
    [HideInInspector] public bool canSkip;
    [HideInInspector] public bool textShown;
    public float delayTime;
    bool delay;
    private void Update()
    {
        if (!delay)
        {
            if (delayTime != FindObjectOfType<PixelCrushers.DialogueSystem.TextAnimatorSubtitlePanel>().delayTime)
            {
                FindObjectOfType<PixelCrushers.DialogueSystem.TextAnimatorSubtitlePanel>().delayTime = delayTime;
                delay = true;
            }
        }
    }
    public void PauseGame()
    {
        //Time.timeScale = 0f;
        FindObjectOfType<SetText>().stopAuto = true;
        FindObjectOfType<ClickToContinue>().canAuto = false;
        FindObjectOfType<ClickToContinue>().autoCooldown = false;
    }
    public void ResumeGame()
    {
        //Time.timeScale = 1f;
        FindObjectOfType<ClickToContinue>().canAuto = true;
    }
    public void DeleteHistory()
    {
        dialogHistory.text = "";
    }
    public void Skip()
    {
        if (canSkip)
        {
            SpawnPanelFade.SpawnFadeOutPanelSkip();
            FindObjectOfType<CommandBehaviours>().isSkiping = true;
            FindObjectOfType<ClickToContinue>().skip = true;
            FindObjectOfType<SpawnPanelFade>().loadingGameObject.SetActive(true);
            AudioManager.skipping = true;
            AudioManager.startSkipping = true;
            FeedbackContainer.skip = true;
        }
    }
    public void Auto()
    {
        if (!FindObjectOfType<SetText>().stopAuto)
        {
            if (!textShown)
            {
                FindObjectOfType<ClickToContinue>().OnAuto(true);
                FindObjectOfType<StandardUIContinueButtonFastForward>().OnFastForward();
            }
            else
            {
                FindObjectOfType<ClickToContinue>().OnAutoAfterTextShown(true);
                FindObjectOfType<StandardUIContinueButtonFastForward>().OnFastForward();
                //textShown = false;
            }
        }
    }
    /*public void SaveGame()
    {
        var saveSystem = GameObjectUtility.FindFirstObjectByType<SaveSystem>();
        if (saveSystem != null)
        {
            SaveSystem.SaveToSlot(1);
        }
        else
        {
            string saveData = PersistentDataManager.GetSaveData();
            PlayerPrefs.SetString("SavedGame", saveData);
            Debug.Log("Save Game Data: " + saveData);
        }
        DialogueManager.ShowAlert("Game saved.");
    }*/
}
