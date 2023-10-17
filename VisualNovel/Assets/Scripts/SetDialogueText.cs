using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDialogueText : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text historyText;

    static string currentDialogue;
    static string currentNpcName;

    static bool dialogue;
    static bool npcName;
    public void SetHistory()
    {
        if (dialogue && npcName)
        {
            if (currentDialogue.Length > 2 && currentNpcName.Length > 2)
            {
                historyText.text += currentNpcName + ": " + currentDialogue + "\n" + "\n" + "\n";
                dialogue = false;
                npcName = false;
            }
        }
    }
    public static void SetTextOnHistory(string i)
    {
        currentDialogue = i;
        dialogue = true;
    }
    public static void SetNameOnHistory(string i)
    {
        currentNpcName = i;
        npcName = true;
    }
}
