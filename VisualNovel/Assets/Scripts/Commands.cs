using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

[RequireComponent(typeof (CommandBehaviours))]
public class Commands : MonoBehaviour
{
    CommandBehaviours commandBehaviours;

    public char commandID;
    [SerializeField] string[] commands;
    public char[] substringIndexOfCommands;
    [SerializeField] char[] substringIndexOfName;

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
            string commandOutput = commandID + command;

            if (currentText.Contains(commandOutput))
            {
                if (commandOutput != commandID + "name")
                {
                    commandBehaviours.PlayCommandGame(commandOutput);
                }
                else
                {
                    PlayComandName();
                }

                dialogueOutput = currentText.Replace(commandOutput, "");
                currentText = dialogueOutput;
            }
        }
        
        return dialogueOutput;
    }
    void PlayComandName()
    {
        nameOutput = currentText.Substring(currentText.IndexOf(substringIndexOfName[0]) + 1, currentText.IndexOf(substringIndexOfName[1]) - currentText.IndexOf(substringIndexOfName[0]) - 1);
        currentText = currentText.Replace(substringIndexOfName[0] + nameOutput + substringIndexOfName[1], "");
        Debug.Log(nameOutput);
    }
    
}

