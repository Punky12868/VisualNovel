using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class CG : MonoBehaviour
{
    public Image[] cgs;
    public Image[] cgs_Slot;

    Texture2D[] loadedCaptures;
    private void Start()
    {
        for (int i = 0; i < cgs.Length; i++)
        {
            if (cgs[i].sprite != FindObjectOfType<GameAssets>().backgrounds[i + 43])
            {
                cgs[i].sprite = FindObjectOfType<GameAssets>().backgrounds[i + 43];
            }
        }
        LoadPhoto();
    }
    public void GetCG(int i)
    {
        Debug.Log("Original_CG: " + i);
        i = i - 43;
        Debug.Log("New_CG: " + i);
        SetCG(i);
    }
    void SetCG(int i)
    {
        Sprite cgSprite = cgs[i].sprite;
        cgs_Slot[i].sprite = cgSprite;
        SavePhoto();
    }
    void SavePhoto()
    {
        for (int i = 0; i < cgs.Length; i++)
        {
            WriteTextureToPlayerPrefs("CG_ID_" + i, cgs_Slot[i].sprite.texture);
        }
    }
    public void LoadPhoto()
    {
        loadedCaptures = new Texture2D[cgs.Length];

        for (int i = 0; i < cgs.Length; i++)
        {
            loadedCaptures[i] = ReadTextureFromPlayerPrefs("CG_ID_" + i);

            if (loadedCaptures[i] != null)
            {
                Sprite photoSprite = Sprite.Create(loadedCaptures[i], new Rect(0, 0, loadedCaptures[i].width, loadedCaptures[i].height), new Vector2(0.5f, 0.5f), 100.0f);

                cgs_Slot[i].sprite = photoSprite;
            }
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
