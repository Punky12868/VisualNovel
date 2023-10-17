using PixelCrushers.DialogueSystem.VisualNovelFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TapeButtonsBehaviour : MonoBehaviour
{
    [SerializeField] SaveHelper saveHandler;

    //-------------------------------------------------------> PLAY

    public void NewGame(int i)
    {
        //saveHandler.LoadGame(i);
        //saveHandler.RestartGame();
        //saveHandler.RestartGameCustom(i);
        SceneManager.LoadScene(i);
    }
    public void ContinueGame()
    {
        saveHandler.LoadLastSavedGame();
        //SceneManager.LoadScene(i);
    }

    //-------------------------------------------------------> CREDITS

    public void Credits(int i)
    {
        SceneManager.LoadScene(i);
    }

    //-------------------------------------------------------> QUIT

    public void QuitGame()
    {
        Application.Quit();
    }
}
