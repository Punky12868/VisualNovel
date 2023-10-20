using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InputEventMapping : MonoBehaviour
{
    public int GameplayScene;

    public UnityEvent SimulateClick;

    public UnityEvent OpenMenu;
    public UnityEvent CloseMenu;

    bool isMenuOpen;

    public UnityEvent DoSkip;
    public UnityEvent StopSkip;

    public static bool isSkipping;

    public UnityEvent OpenBacklog;

    public UnityEvent OpenSaveSlot;

    public UnityEvent OpenLoadSlot;

    public UnityEvent QuickSave;
    public UnityEvent QuickLoad;

    public UnityEvent ToggleAuto;
    public UnityEvent UntoggleAuto;

    public static bool isAuto;

    private void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == GameplayScene)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                SimulateClick.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isMenuOpen)
                {
                    OpenMenu.Invoke();
                    isMenuOpen = true;
                }
                else
                {
                    CloseMenu.Invoke();
                    isMenuOpen = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                DoSkip.Invoke();
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                StopSkip.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!isSkipping)
                {
                    DoSkip.Invoke();
                }
                else
                {
                    StopSkip.Invoke();
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                if (!isMenuOpen)
                {
                    OpenBacklog.Invoke();
                    isMenuOpen = true;
                }
                
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (!isMenuOpen)
                {
                    OpenSaveSlot.Invoke();
                    isMenuOpen = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                if (!isMenuOpen)
                {
                    OpenLoadSlot.Invoke();
                    isMenuOpen = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.F5))
            {
                QuickSave.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.F9))
            {
                QuickSave.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!isAuto)
                {
                    ToggleAuto.Invoke();
                }
                else
                {
                    UntoggleAuto.Invoke();
                }
            }
        }
        else
        {
            if (isMenuOpen || isSkipping || isAuto)
            {
                isMenuOpen = false;
                isSkipping = false;
                isAuto = false;
            }
        }
    }
}
