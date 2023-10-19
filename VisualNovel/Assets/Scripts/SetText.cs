using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;
using UnityEngine;
using Febucci.UI;
using TMPro;

public class SetText : MonoBehaviour
{
    string stored_txt;
    string txt;
    bool change;

    [HideInInspector] public bool stopAuto;
    private void Update()
    {
        if (!change)
        {
            if (txt != GetComponent<TMP_Text>().text)
            {
                if (GetComponent<TMP_Text>().text.Contains(FindObjectOfType<Commands>().commandID))
                {
                    FindObjectOfType<Commands>().currentText = GetComponent<TMP_Text>().text;
                    txt = FindObjectOfType<Commands>().SetCustomSubtitles();
                    string fixedTxt = RemoveNumbersFromText(txt);
                    txt = fixedTxt;
                    GetComponent<TMP_Text>().text = fixedTxt;
                    FindObjectOfType<ClickToContinue>().textLenght = fixedTxt.Length;

                    SetDialogueText.SetTextOnHistory(txt);
                }
                else
                {
                    txt = GetComponent<TMP_Text>().text;

                    SetDialogueText.SetTextOnHistory(txt);
                }
            }
        }
    }
    public void Change(bool a)
    {
        if (a)
        {
            change = a;
            GetComponent<TypewriterByCharacter>().StopShowingText();
            GetComponent<TMP_Text>().text = "";
            stored_txt = txt;
        }
        else
        {
            GetComponent<TypewriterByCharacter>().StartShowingText();
            txt = stored_txt;
            GetComponent<TMP_Text>().text = txt;
            change = a;
        }
    }
    string RemoveNumbersFromText(string inputText)
    {
        string pattern = @"\(\d+(\,\d+)*\)";
        string textWithoutNumbers = Regex.Replace(inputText, pattern, "");
        return textWithoutNumbers;
    }
    public void AutoText()
    {
        if (!FindObjectOfType<ClickToContinue>().auto)
        {
            FindObjectOfType<ButtonBehaviours>().textShown = true;
        }

        if (!stopAuto)
        {
            FindObjectOfType<ClickToContinue>().Auto();
            Debug.Log("AUTOATUOATUAOTISAOUTIOAST");
        }
        else
        {
            Debug.Log("AJDISOADNOIASD");
            stopAuto = false;
        }
    }
}