using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOrNewGame : MonoBehaviour
{
    [SerializeField] PixelCrushers.DialogueSystem.VisualNovelFramework.LoadGamePanel loadGamePanel;
    [SerializeField] GameObject loadDestroyPanel;
    [SerializeField] GameObject newGamePanel;
    public void LoadDestroy(bool i)
    {
        if (i)
        {
            if (loadGamePanel.CheckSlot())
            {
                loadDestroyPanel.SetActive(true);
            }
            else
            {
                newGamePanel.SetActive(true);
            }
        }
        else
        {
            loadDestroyPanel.SetActive(false);
            newGamePanel.SetActive(false);
        }
    }
}
