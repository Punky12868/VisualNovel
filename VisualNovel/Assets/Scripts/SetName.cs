using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetName : MonoBehaviour
{
    string txt;
    private void Update()
    {
        if (txt != GetComponent<TMP_Text>().text || txt != FindObjectOfType<Commands>().nameOutput)
        {
            txt = FindObjectOfType<Commands>().nameOutput;
            GetComponent<TMP_Text>().text = txt;
            //Debug.Log("SetName IsRunning");
        }
    }
}
