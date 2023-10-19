using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class CGOpenImage : MonoBehaviour
{
    [SerializeField] Image cgBigSlot;

    [SerializeField] Image[] cgSlots;
    Texture2D[] loadedCaptures;
    private void Awake()
    {
        LoadPhoto();
    }
    public void LoadPhoto()
    {
        loadedCaptures = new Texture2D[cgSlots.Length];

        for (int i = 0; i < cgSlots.Length; i++)
        {
            loadedCaptures[i] = ReadTextureFromPlayerPrefs("CG_ID_" + i);

            if (loadedCaptures[i] != null)
            {
                Sprite photoSprite = Sprite.Create(loadedCaptures[i], new Rect(0, 0, loadedCaptures[i].width, loadedCaptures[i].height), new Vector2(0.5f, 0.5f), 100.0f);

                cgSlots[i].sprite = photoSprite;
            }
        }
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
    public void SetImage(int i)
    {
        cgBigSlot.sprite = cgSlots[i - 1].sprite;
    }
}
