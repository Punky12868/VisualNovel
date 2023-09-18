using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class SetText : MonoBehaviour
{
    string txt;
    private void Update()
    {
        if (txt != GetComponent<TMP_Text>().text)
        {
            FindObjectOfType<Commands>().currentText = GetComponent<TMP_Text>().text;
            txt = FindObjectOfType<Commands>().SetCustomSubtitles();
            string fixedTxt = RemoveNumbersFromText(txt);
            txt = fixedTxt;
            GetComponent<TMP_Text>().text = fixedTxt;

            /*FindObjectOfType<Commands>().currentText = GetComponent<TMP_Text>().text;
            txt = FindObjectOfType<Commands>().SetCustomSubtitles();
            GetComponent<TMP_Text>().text = txt;*/
            //Debug.Log("SetText IsRunning");
        }
    }

    string RemoveNumbersFromText(string inputText)
    {
        string pattern = @"\(\d+\)";
        string replacement = "";
        string textWithoutNumbers = Regex.Replace(inputText, pattern, replacement);
        return textWithoutNumbers;
    }
}