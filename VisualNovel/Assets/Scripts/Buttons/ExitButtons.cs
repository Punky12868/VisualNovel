using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitButtons : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
