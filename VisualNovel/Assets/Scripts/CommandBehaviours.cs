using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandBehaviours : MonoBehaviour
{
    Commands commands;
    GameAssets assets;
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

                assets.currentBG.sprite = assets.backgrounds[BackGround()];
                Debug.Log("BackGround Change: BG ID: " + BackGround());

                break;
            case string a when a.Contains(commands.commandID + "sprite"):

                assets.currentSprite.sprite = assets.npcSrites[Sprite()];
                Debug.Log("Npc Sprite Change: Sprite ID: " + Sprite());

                break;
            case string a when a.Contains(commands.commandID + "clear"):

                int i = Clear();
                Debug.Log("Clear (')");

                break;
            case string a when a.Contains(commands.commandID + "fadein"):

                SpawnPanelFade.SpawnFadeInPanel();

                break;
            case string a when a.Contains(commands.commandID + "fadeBG"):

                SpawnPanelFade.SpawnFadeInPanelBG();

                break;

            case string a when a.Contains(commands.commandID + "fadeSPR"):
                SpawnPanelFade.SpawnFadeInPanelSPR();

                break;
            case string a when a.Contains(commands.commandID + "fadeBoth"):

                SpawnPanelFade.SpawnFadeInPanelBoth();

                break;
            default:
                break;
        }
    }
    int BackGround()
    {
        int i;
        string numberStr = commands.currentText.Substring(commands.currentText.IndexOf(commands.substringIndexOfCommands[0]) + 1, commands.currentText.IndexOf(commands.substringIndexOfCommands[1]) - commands.currentText.IndexOf(commands.substringIndexOfCommands[0]) - 1);
        int.TryParse(numberStr, out i);
        return i;
    }
    int Sprite()
    {
        int i;
        string numberStr = commands.currentText.Substring(commands.currentText.IndexOf(commands.substringIndexOfCommands[0]) + 1, commands.currentText.IndexOf(commands.substringIndexOfCommands[1]) - commands.currentText.IndexOf(commands.substringIndexOfCommands[0]) - 1);
        int.TryParse(numberStr, out i);
        return i;
    }
    public int Fade()
    {
        int i;
        string numberStr = commands.currentText.Substring(commands.currentText.IndexOf(commands.substringIndexOfCommands[0]) + 1, commands.currentText.IndexOf(commands.substringIndexOfCommands[1]) - commands.currentText.IndexOf(commands.substringIndexOfCommands[0]) - 1);
        int.TryParse(numberStr, out i);
        return i;
    }
    int Clear()
    {
        int i;
        string numberStr = commands.currentText.Substring(commands.currentText.IndexOf(commands.substringIndexOfCommands[0]) + 1, commands.currentText.IndexOf(commands.substringIndexOfCommands[1]) - commands.currentText.IndexOf(commands.substringIndexOfCommands[0]) - 1);
        int.TryParse(numberStr, out i);
        commands.currentText = commands.currentText.Replace(commands.substringIndexOfCommands[0] + numberStr + commands.substringIndexOfCommands[1], "");
        return i;
    }
}
