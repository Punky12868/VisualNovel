using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetName : MonoBehaviour
{
    string stored_txt;
    string txt;
    bool change;
    private void Update()
    {
        if (!change)
        {
            if (txt != GetComponent<TMP_Text>().text || txt != FindObjectOfType<Commands>().nameOutput)
            {
                txt = FindObjectOfType<Commands>().nameOutput;
                GetComponent<TMP_Text>().text = txt;
                FindObjectOfType<GameAssets>().currentNpcName = GetComponent<TMP_Text>().text;
                txt = FindObjectOfType<GameAssets>().currentNpcName;

                if (FindObjectOfType<GameAssets>().currentNpcName == "Catname")
                {
                    GetComponent<TMP_Text>().text = FindObjectOfType<GameAssets>().catName;
                    txt = GetComponent<TMP_Text>().text;
                }

                //Debug.Log("SetName IsRunning");
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
}
