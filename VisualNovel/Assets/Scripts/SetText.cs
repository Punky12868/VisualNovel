using System.Collections;
using System.Collections.Generic;
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
            GetComponent<TMP_Text>().text = txt;
            //Debug.Log("SetText IsRunning");
        }
    }
}