using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ImageSlot : MonoBehaviour
{
    Image imagePanel;
    [HideInInspector] public Image imageForSingleSlot;
    [SerializeField] int index;
    private void Awake()
    {
        imageForSingleSlot = GetComponent<Image>();
        imagePanel = FindObjectOfType<TakeAndDisplayScreenshot>().photoDisplay[index - 1];
        imageForSingleSlot.sprite = FindObjectOfType<TakeAndDisplayScreenshot>().photoDisplay[index - 1].sprite;
    }
    private void Update()
    {
        if (imageForSingleSlot.sprite != imagePanel.sprite)
        {
            imageForSingleSlot.sprite = imagePanel.sprite;
        }
    }
    public void CheckTumbnails()
    {
        imageForSingleSlot.sprite = imagePanel.sprite;
    }
}
