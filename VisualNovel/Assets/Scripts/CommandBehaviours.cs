using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CommandBehaviours : MonoBehaviour
{
    Commands commands;
    GameAssets assets;
    AudioManager audioAssets;

    [HideInInspector] public int fadeBG;
    [HideInInspector] public int[] fadeSPR;
    [HideInInspector] public int[] fadeBoth;

    [HideInInspector] public bool isSkiping;
    private void Awake()
    {
        commands = GetComponent<Commands>();
        assets = GetComponent<GameAssets>();
        audioAssets = FindObjectOfType<AudioManager>();
    }
    public void PlayCommandGame(string command)
    {
        switch (command)
        {
            case string a when a.Contains(commands.commandID + "bg"):

                assets.currentBG.sprite = assets.backgrounds[GetBackgroundID()];

                break;

            case string a when a.Contains(commands.commandID + "sprite"):

                int[] i = GetSpriteID();
                assets.currentSpriteOne.sprite = assets.npcSrites[i[0]];
                assets.currentSpriteTwo.sprite = assets.npcSrites[i[1]];

                break;

            case string a when a.Contains(commands.commandID + "textBoxChange"):

                assets.currentTextbox.sprite = assets.textboxSprites[GetTextBoxID()];

                break;

            case string a when a.Contains(commands.commandID + "textboxShow"):

                FindObjectOfType<TextBoxOpacity>().fadeTxtBoxValue = 1;

                break;

            case string a when a.Contains(commands.commandID + "textboxHide"):

                FindObjectOfType<TextBoxOpacity>().fadeTxtBoxValue = 0;

                break;

            case string a when a.Contains(commands.commandID + "cameraShake"):

                CameraShake.isShaking = true;

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

                fadeBoth = GetFadeBothIDs();
                SpawnPanelFade.SpawnFadeInPanelBoth();

                break;

            case string a when a.Contains(commands.commandID + "fadeOpacityOneSPR"):

                FindObjectOfType<sprOne_Fade>().fadeSPRValue = GetAlphaValueOneSPR();

                break;

            case string a when a.Contains(commands.commandID + "fadeOpacityTwoSPR"):

                FindObjectOfType<sprTwo_Fade>().fadeSPRValue = GetAlphaValueTwoSPR();

                break;

            case string a when a.Contains(commands.commandID + "FadeColorSPR"):

                int[] y = GetColorValueSPR();
                if (y[0] == 0)
                {
                    FindObjectOfType<sprOne_Fade>().colorSPRValue = y[1];
                }
                else if (y[0] == 1)
                {
                    FindObjectOfType<sprTwo_Fade>().colorSPRValue = y[1];
                }
                else
                {
                    Debug.Log("Invalid_SPR_ID");
                }

                break;

            case string a when a.Contains(commands.commandID + "getSPROnePos"):

                FindObjectOfType<SpritePosition>().spriteOnePosIndex = GetSpriteOnePosition();

                break;

            case string a when a.Contains(commands.commandID + "getSPRTwoPos"):

                FindObjectOfType<SpritePosition>().spriteTwoPosIndex = GetSpriteTwoPosition();

                break;

            case string a when a.Contains(commands.commandID + "BGM"):

                audioAssets.ChangeMusic(assets.BGM[GetBGM()]);

                break;

            case string a when a.Contains(commands.commandID + "SFX"):

                audioAssets.PlaySoundFX(assets.SFX[GetSFX()]);

                break;

            case string a when a.Contains(commands.commandID + "end"):

                FindObjectOfType<ClickToContinue>().enabled = false;

                break;

            case string a when a.Contains(commands.commandID + "canSkip"):

                    FindObjectOfType<ClickToContinue>().stopSkip = false;
                FindObjectOfType<ButtonBehaviours>().canSkip = true;
                FindObjectOfType<ClickToContinue>().canAuto = true;

                break;

            case string a when a.Contains(commands.commandID + "stopSkip"):

                FindObjectOfType<SpawnPanelFade>().loadingGameObject.SetActive(false);
                FindObjectOfType<ClickToContinue>().stopSkip = true;
                FindObjectOfType<ClickToContinue>().skip = false;
                FindObjectOfType<SetText>().stopAuto = true;
                FindObjectOfType<ButtonBehaviours>().canSkip = false;
                FindObjectOfType<ClickToContinue>().canAuto = false;
                FindObjectOfType<ClickToContinue>().autoCooldown = false;
                Debug.Log("AAA");

                break;

            default:
                break;
        }
    }
    public int GetBackgroundID()
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
    public int[] GetSpriteID()
    {
        int[] ids = new int[2];

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
                    string content = commands.currentText.Substring(numberStartIndex, numberEndIndex - numberStartIndex);

                    string[] numberStrs = content.Split(commands.commandSeparator);

                    if (numberStrs.Length == 2)
                    {
                        int.TryParse(numberStrs[0].Trim(), out ids[0]);
                        int.TryParse(numberStrs[1].Trim(), out ids[1]);
                    }
                }
            }
        }

        return ids;
    }
    public int GetTextBoxID()
    {
        int i;
        string command = commands.commandID + "textBoxChange";
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
    public int[] GetFadeSPR_ID()
    {
        int[] ids = new int[2];

        string command = commands.commandID + "fadeSPR";
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
                    string content = commands.currentText.Substring(numberStartIndex, numberEndIndex - numberStartIndex);

                    string[] numberStrs = content.Split(commands.commandSeparator);

                    if (numberStrs.Length == 2)
                    {
                        int.TryParse(numberStrs[0].Trim(), out ids[0]);
                        int.TryParse(numberStrs[1].Trim(), out ids[1]);
                    }
                }
            }
        }

        return ids;
    }
    public int[] GetFadeBothIDs()
    {
        #region backuo
        int[] ids = new int[3];

        string command = commands.commandID + "fadeBoth";
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
                    string content = commands.currentText.Substring(numberStartIndex, numberEndIndex - numberStartIndex);

                    string[] numberStrs = content.Split(commands.commandSeparator);

                    if (numberStrs.Length == 3)
                    {
                        int.TryParse(numberStrs[0].Trim(), out ids[0]);
                        int.TryParse(numberStrs[1].Trim(), out ids[1]);
                        int.TryParse(numberStrs[2].Trim(), out ids[2]);
                    }
                }
            }
        }

        return ids;
        #endregion
    }
    public int GetAlphaValueOneSPR()
    {
        int i;
        string command;
        command = commands.commandID + "fadeOpacityOneSPR";

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
    public int GetAlphaValueTwoSPR()
    {
        int i;
        string command;
        command = commands.commandID + "fadeOpacityTwoSPR";

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
    public int[] GetColorValueSPR()
    {
        int[] ids = new int[2];

        string command = commands.commandID + "FadeColorSPR";
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
                    string content = commands.currentText.Substring(numberStartIndex, numberEndIndex - numberStartIndex);

                    string[] numberStrs = content.Split(commands.commandSeparator);

                    if (numberStrs.Length == 2)
                    {
                        int.TryParse(numberStrs[0].Trim(), out ids[0]);
                        int.TryParse(numberStrs[1].Trim(), out ids[1]);
                    }
                }
            }
        }

        return ids;
    }
    public int GetSpriteOnePosition()
    {
        int i;
        string command = commands.commandID + "getSPROnePos";
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
                        Debug.LogError("Failed to parse BGM_ID.");
                    }
                }
            }
        }

        Debug.LogError("BGM_ID not found.");
        return -1;
    }
    public int GetSpriteTwoPosition()
    {
        int i;
        string command = commands.commandID + "getSPRTwoPos";
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
                        Debug.LogError("Failed to parse BGM_ID.");
                    }
                }
            }
        }

        Debug.LogError("BGM_ID not found.");
        return -1;
    }
    public int GetBGM()
    {
        int i;
        string command = commands.commandID + "BGM";
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
                        Debug.LogError("Failed to parse BGM_ID.");
                    }
                }
            }
        }

        Debug.LogError("BGM_ID not found.");
        return -1;
    }
    public int GetSFX()
    {
        int i;
        string command = commands.commandID + "SFX";
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
                        Debug.LogError("Failed to parse SFX_ID.");
                    }
                }
            }
        }

        Debug.LogError("SFX_ID not found.");
        return -1;
    }
}