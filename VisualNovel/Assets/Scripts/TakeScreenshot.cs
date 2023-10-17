using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class TakeScreenshot : MonoBehaviour
{
    Image screenshotDisplay;
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
        screenshotDisplay.overrideSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0f, 0f), 100f);
    }
    IEnumerator takeScreenshot()
    {
        ScreenCapture.CaptureScreenshot("save_thumbnail.png", 0);

        yield return new WaitForEndOfFrame();
        yield return new WaitForSecondsRealtime(1.5f);

        GetPhoto();
    }
}
