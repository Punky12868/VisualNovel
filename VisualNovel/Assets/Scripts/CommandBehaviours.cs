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
            case "°bg":
                assets.currentBG.sprite = assets.backgrounds[BackGround()];
                Debug.Log("BackGround Change: BG ID: " + BackGround());
                break;
            case "°sprite":
                assets.currentSprite.sprite = assets.npcSrites[Sprite()];
                Debug.Log("Npc Sprite Change: Sprite ID: " + Sprite());
                break;
            case "°clear":
                int i = Clear();
                Debug.Log("Clear (')");
                break;
            case "°fadein":
                SpawnPanelFade.SpawnFadeInPanel();
                break;
            case "°fadeBG":
                SpawnPanelFade.SpawnFadeInPanelBG();
                break;
            case "°fadeSPR":
                SpawnPanelFade.SpawnFadeInPanelSPR();
                break;
            case "°fadeBoth":
                SpawnPanelFade.SpawnFadeInPanelBoth();
                break;
            default:
                break;
        }
    }
    int BackGround()
    {
        int i;
        string numberStr = commands.currentText.Substring(commands.currentText.IndexOf('(') + 1, commands.currentText.IndexOf(')') - commands.currentText.IndexOf('(') - 1);
        int.TryParse(numberStr, out i);
        return i;
    }
    int Sprite()
    {
        int i;
        string numberStr = commands.currentText.Substring(commands.currentText.IndexOf('(') + 1, commands.currentText.IndexOf(')') - commands.currentText.IndexOf('(') - 1);
        int.TryParse(numberStr, out i);
        return i;
    }
    public int Fade()
    {
        int i;
        string numberStr = commands.currentText.Substring(commands.currentText.IndexOf('(') + 1, commands.currentText.IndexOf(')') - commands.currentText.IndexOf('(') - 1);
        int.TryParse(numberStr, out i);
        return i;
    }
    int Clear()
    {
        int i;
        string numberStr = commands.currentText.Substring(commands.currentText.IndexOf('(') + 1, commands.currentText.IndexOf(')') - commands.currentText.IndexOf('(') - 1);
        int.TryParse(numberStr, out i);
        commands.currentText = commands.currentText.Replace("(" + numberStr + ")", "");
        return i;
    }
}
