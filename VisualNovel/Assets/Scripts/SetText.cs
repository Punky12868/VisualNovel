using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    string stored_txt;
    string txt;
    bool change;
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
                }
                else
                {
                    txt = GetComponent<TMP_Text>().text;
                }
            }
        }
    }
    public void Change(bool a)
    {
        if (a)
        {
            change = a;
            stored_txt = txt;
            GetComponent<TMP_Text>().text = "";
        }
        else
        {
            txt = stored_txt;
            GetComponent<TMP_Text>().text = txt;
            change = a;
        }
    }
    string RemoveNumbersFromText(string inputText)
    {
        string pattern = @"\(\d+([,.]\d+)?\)";
        string textWithoutNumbers = Regex.Replace(inputText, pattern, "");
        return textWithoutNumbers;
    }
}