using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

[RequireComponent(typeof (CommandBehaviours))]
public class Commands : MonoBehaviour
{
    CommandBehaviours commandBehaviours;
    [SerializeField] string[] commands;

    [HideInInspector] public string currentText;

    [HideInInspector] public string dialogueOutput = "";
    [HideInInspector] public string nameOutput = "";
    private void Awake()
    {
        commandBehaviours = GetComponent<CommandBehaviours>();
    }
    public string SetCustomSubtitles()
    {
        foreach (string command in commands)
        {
            if (currentText.Contains(command))
            {
                if (command != "°name")
                {
                    commandBehaviours.PlayCommandGame(command);
                }
                else
                {
                    PlayComandName();
                }

                dialogueOutput = currentText.Replace(command, "");
                currentText = dialogueOutput;
            }
        }
        
        return dialogueOutput;
    }
    void PlayComandName()
    {
        nameOutput = currentText.Substring(currentText.IndexOf('<') + 1, currentText.IndexOf('>') - currentText.IndexOf('<') - 1);
        currentText = currentText.Replace("<" + nameOutput + ">", "");
        Debug.Log(nameOutput);
    }
    
}

