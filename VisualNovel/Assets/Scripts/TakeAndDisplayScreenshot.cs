using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using System;

public class TakeAndDisplayScreenshot : MonoBehaviour
{
    public Image[] photoDisplay;
    public Sprite nullSprite;
    [SerializeField] GameObject hideSettingsUI;
    ImageSlot[] imageSlots;
    Texture2D screenCapture;
    Texture2D[] loadedCaptures;

    bool notActivateUI;
    private void Start()
    {
        imageSlots = FindObjectsOfType<ImageSlot>();
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        LoadPhoto();
        //saveGamePanel.CheckSavedGames();
    }

    public void TakePhotoOnSave(int i)
    {
        StartCoroutine(CapturePhoto(i));
    }

    public void SaveDeletePhotoOnClick()
    {
        SavePhoto();
    }

    IEnumerator CapturePhoto(int panelIndex)
    {
        if (!hideSettingsUI.activeInHierarchy)
        {
            notActivateUI = true;
        }

        hideSettingsUI.SetActive(false);

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);
        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();

        yield return new WaitForEndOfFrame();

        if (!notActivateUI)
        {
            hideSettingsUI.SetActive(true);
        }
        else
        {
            notActivateUI = false;
        }

        ShowPhoto(panelIndex);
    }

    void ShowPhoto(int panelIndex)
    {
        // Create a copy of the texture to make it readable
        Texture2D copiedTexture = new Texture2D(screenCapture.width, screenCapture.height);
        copiedTexture.SetPixels(screenCapture.GetPixels());
        copiedTexture.Apply();

        Sprite photoSprite = Sprite.Create(copiedTexture, new Rect(0, 0, copiedTexture.width, copiedTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplay[panelIndex].sprite = photoSprite;
        SavePhoto();

        for (int i = 0; i < imageSlots.Length; i++)
        {
            imageSlots[i].CheckTumbnails();
        }
    }

    void SavePhoto()
    {
        for (int i = 0; i < photoDisplay.Length; i++)
        {
            WriteTextureToPlayerPrefs("ID_" + i, photoDisplay[i].sprite.texture);
        }
    }

    public void LoadPhoto()
    {
        loadedCaptures = new Texture2D[photoDisplay.Length];

        for (int i = 0; i < photoDisplay.Length; i++)
        {
            loadedCaptures[i] = ReadTextureFromPlayerPrefs("ID_" + i);

            if (loadedCaptures[i] != null)
            {
                Sprite photoSprite = Sprite.Create(loadedCaptures[i], new Rect(0, 0, loadedCaptures[i].width, loadedCaptures[i].height), new Vector2(0.5f, 0.5f), 100.0f);
                photoDisplay[i].sprite = photoSprite;
            }
        }

        for (int i = 0; i < imageSlots.Length; i++)
        {
            imageSlots[i].CheckTumbnails();
        }
    }

    public static void WriteTextureToPlayerPrefs(string tag, Texture2D tex)
    {
        byte[] texByte = tex.EncodeToPNG();

        string base64Tex = Convert.ToBase64String(texByte);
        PlayerPrefs.SetString(tag, base64Tex);
        PlayerPrefs.Save();
    }

    public static Texture2D ReadTextureFromPlayerPrefs(string tag)
    {
        string base64Tex = PlayerPrefs.GetString(tag, null);

        if (!string.IsNullOrEmpty(base64Tex))
        {
            byte[] texByte = Convert.FromBase64String(base64Tex);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(texByte);
            return tex;
        }

        return null;
    }
}
