using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CommandBehaviours : MonoBehaviour
{
    Commands commands;
    GameAssets assets;

    [HideInInspector] public int fadeBG;
    [HideInInspector] public int fadeSPR;
    private void Awake()
    {
        commands = GetComponent<Commands>();
        assets = GetComponent<GameAssets>();
    }
    public void PlayCommandGame(string command)
    {
        switch (command)
        {
            case string a when a.Contains(commands.commandID + "bg"):

                int x = GetBackGroundID();
                assets.currentBG.sprite = assets.backgrounds[x];
                //Debug.Log("BackGround Change: BG ID: " + GetBackGroundID());

                break;
            case string a when a.Contains(commands.commandID + "sprite"):

                int y = GetSpriteID();
                assets.currentSprite.sprite = assets.npcSrites[y];
                //Debug.Log("Npc Sprite Change: Sprite ID: " + GetSpriteID());

                break;
            case string a when a.Contains(commands.commandID + "fadein"):

                SpawnPanelFade.SpawnFadeInPanel();

                break;
            case string a when a.Contains(commands.commandID + "fadeBG"):

                fadeBG = GetFadeBG_ID();
                SpawnPanelFade.SpawnFadeInPanelBG();

                break;

            case string a when a.Contains(commands.commandID + "fadeSPR"):

                fadeSPR = GetFadeSPR_ID();
                SpawnPanelFade.SpawnFadeInPanelSPR();

                break;
            case string a when a.Contains(commands.commandID + "fadeBoth"):

                SpawnPanelFade.SpawnFadeInPanelBoth();

                break;

            case string a when a.Contains(commands.commandID + "FadeOpacity_SPR"):

                GetFadeOpacitySPR(a);

                break;

            case string a when a.Contains(commands.commandID + "FadeColor_SPR"):

                GetFadeColorSPR(a);

                break;

            default:
                break;
        }
    }
    int GetBackGroundID()
    {
        int i;
        string command = commands.commandID + "bg";
        int startIndex = commands.currentText.IndexOf(command);

        if (startIndex != -1)
        {
            startIndex += command.Length;

            int numberStartIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[0], startIndex);

            if (numberStartIndex != -1)
            {
                numberStartIndex++;

                int numberEndIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[1], numberStartIndex);

                if (numberEndIndex != -1)
                {
                    string numberStr = commands.currentText.Substring(numberStartIndex, numberEndIndex - numberStartIndex);

                    if (int.TryParse(numberStr, out i))
                    {
                        //Debug.Log("BG_ID: " + i);
                        return i;
                    }
                    else
                    {
                        Debug.LogError("Failed to parse BG_ID.");
                    }
                }
            }
        }

        Debug.LogError("BG_ID not found.");
        return -1;
    }
    int GetSpriteID()
    {
        int i;
        string command = commands.commandID + "sprite";
        int startIndex = commands.currentText.IndexOf(command);

        if (startIndex != -1)
        {
            startIndex += command.Length;

            int numberStartIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[0], startIndex);

            if (numberStartIndex != -1)
            {
                numberStartIndex++;

                int numberEndIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[1], numberStartIndex);

                if (numberEndIndex != -1)
                {
                    string numberStr = commands.currentText.Substring(numberStartIndex, numberEndIndex - numberStartIndex);

                    if (int.TryParse(numberStr, out i))
                    {
                        //Debug.Log("SPR_ID: " + i);
                        return i;
                    }
                    else
                    {
                        Debug.LogError("Failed to parse SPR_ID.");
                    }
                }
            }
        }

        Debug.LogError("SPR_ID not found.");
        return -1;
    }
    public int GetFadeBG_ID()
    {
        int i;
        string command;
        command = commands.commandID + "fadeBG";

        int startIndex = commands.currentText.IndexOf(command);

        if (startIndex != -1)
        {
            startIndex += command.Length;

            int numberStartIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[0], startIndex);

            if (numberStartIndex != -1)
            {
                numberStartIndex++;

                int numberEndIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[1], numberStartIndex);

                if (numberEndIndex != -1)
                {
                    string numberStr = commands.currentText.Substring(numberStartIndex, numberEndIndex - numberStartIndex);

                    if (int.TryParse(numberStr, out i))
                    {
                        //Debug.Log("Fade_BG_ID: " + i);
                        return i;
                    }
                    else
                    {
                        Debug.LogError("Failed to parse Fade_BG_ID.");
                    }
                }
            }
        }

        Debug.LogError("Fade_BG_ID not found.");
        return -1;
    }
    public int GetFadeSPR_ID()
    {
        int i;
        string command;
        command = commands.commandID + "fadeSPR";

        int startIndex = commands.currentText.IndexOf(command);

        if (startIndex != -1)
        {
            startIndex += command.Length;

            int numberStartIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[0], startIndex);

            if (numberStartIndex != -1)
            {
                numberStartIndex++;

                int numberEndIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[1], numberStartIndex);

                if (numberEndIndex != -1)
                {
                    string numberStr = commands.currentText.Substring(numberStartIndex, numberEndIndex - numberStartIndex);

                    if (int.TryParse(numberStr, out i))
                    {
                        //Debug.Log("Fade_SPR_ID: " + i);
                        return i;
                    }
                    else
                    {
                        Debug.LogError("Failed to parse Fade_SPR_ID.");
                    }
                }
            }
        }

        Debug.LogError("Fade_SPR_ID not found.");
        return -1;
    }
    public int[] GetFadeBothIDs()
    {
        int[] ids = new int[2];

        int startIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[0]);
        int endIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[1]);

        if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
        {
            string content = commands.currentText.Substring(startIndex + 1, endIndex - startIndex - 1);

            string[] numberStrs = content.Split(commands.commandSeparator);

            if (numberStrs.Length == 2)
            {
                int.TryParse(numberStrs[0].Trim(), out ids[0]);
                int.TryParse(numberStrs[1].Trim(), out ids[1]);
            }
        }

        //Debug.Log("Fades_IDs: " + ids);
        return ids;
    }
    void GetFadeOpacitySPR(string a)
    {
        if (a.Substring(10) == "true")
        {
            FindObjectOfType<spr_Fade>().fadeIn_fade = true;
        }
        else if (a.Substring(10) == "false")
        {
            FindObjectOfType<spr_Fade>().fadeIn_fade = false;
        }
        else
        {
            Debug.Log("Error");
        }
    }
    void GetFadeColorSPR(string a)
    {
        if (a.Substring(10) == "true")
        {
            FindObjectOfType<spr_Fade>().fadeIn_color = true;
        }
        else if (a.Substring(10) == "false")
        {
            FindObjectOfType<spr_Fade>().fadeIn_color = false;
        }
        else
        {
            Debug.Log("Error");
        }
    }
    /*int[] GetSPRBlurIndex()
    {
        int[] ids = new int[2];

        int startIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[0]);
        int endIndex = commands.currentText.IndexOf(commands.substringIndexOfCommands[1]);

        if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
        {
            string content = commands.currentText.Substring(startIndex + 1, endIndex - startIndex - 1);

            string[] numberStrs = content.Split('.');

            if (numberStrs.Length == 2)
            {
                int.TryParse(numberStrs[0].Trim(), out ids[0]);
                int.TryParse(numberStrs[1].Trim(), out ids[1]);
            }
        }

        return ids;
    }*/
}