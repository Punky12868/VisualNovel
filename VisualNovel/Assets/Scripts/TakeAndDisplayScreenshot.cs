using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class TakeAndDisplayScreenshot : MonoBehaviour
{
    [SerializeField] Camera screenshotCamera;
    [SerializeField] GameObject hideCanvas;

    [SerializeField] Image[] loadMenuPanels;

    [SerializeField] Image[] saveGameplayPanels;
    [SerializeField] Image[] loadGameplayPanels;

    int panelIndex;
    bool activateForLoop;
    private void Awake()
    {
        activateForLoop = true;
    }
    private void Update()
    {
        if (activateForLoop)
        {
            for (int i = 0; i < 7; i++)
            {
                loadMenuPanels[panelIndex].overrideSprite = FindObjectOfType<VariableHolder>().slotImage_holder[panelIndex].sprite;

                saveGameplayPanels[panelIndex].overrideSprite = FindObjectOfType<VariableHolder>().slotImage_holder[panelIndex].sprite;
                loadGameplayPanels[panelIndex].overrideSprite = FindObjectOfType<VariableHolder>().slotImage_holder[panelIndex].sprite;

                if (i > 5)
                {
                    activateForLoop = false;
                    break;
                }
            }
        }
    }
    public void SaveButtonPhoto(int i)
    {
        screenshotCamera.gameObject.SetActive(true);

        panelIndex = i - 1;
        StartCoroutine(TakeScreenshot());
    }
    public void GetPhoto()
    {
        string url = Application.persistentDataPath + "/" + "save_thumbnail.png";
        var bytes = File.ReadAllBytes(url);
        Texture2D texture = new Texture2D(2, 2);
        bool imageLoadSuccess = texture.LoadImage(bytes);

        while (!imageLoadSuccess)
        {
            print("Image Load Failed");
            bytes = File.ReadAllBytes(url);
            imageLoadSuccess = texture.LoadImage(bytes);
        }

        print("Image load success: " + imageLoadSuccess);

        /*saveMenuPanels[panelIndex].overrideSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0f, 0f), 100f);*/

        FindObjectOfType<VariableHolder>().slotImage_holder[panelIndex].overrideSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0f, 0f), 100f);
        screenshotCamera.gameObject.SetActive(false);
        activateForLoop = true;
    }
    void SaveCameraView(Camera cam)
    {
        string url = Application.persistentDataPath + "/";
        RenderTexture screenTexture = new RenderTexture(Screen.width, Screen.height, 16);
        cam.targetTexture = screenTexture;
        RenderTexture.active = screenTexture;
        cam.Render();
        Texture2D renderedTexture = new Texture2D(Screen.width, Screen.height);
        renderedTexture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        RenderTexture.active = null;
        byte[] byteArray = renderedTexture.EncodeToPNG();
        File.WriteAllBytes(url + "save_thumbnail.png", byteArray);
    }
    IEnumerator TakeScreenshot()
    {
        yield return null;
        hideCanvas.SetActive(false);
        yield return new WaitForEndOfFrame();
        string url = Application.persistentDataPath + "/";
        ScreenCapture.CaptureScreenshot(url + "save_thumbnail.png", 0);
        //SaveCameraView(screenshotCamera);
        yield return new WaitForEndOfFrame();
        hideCanvas.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);

        GetPhoto();
    }
}
