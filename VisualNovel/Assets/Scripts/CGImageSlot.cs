using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class CGImageSlot : MonoBehaviour
{
    Image buttonImage;
    [SerializeField] int index;
    private void Awake()
    {
        int i = index - 1;
        buttonImage = GetComponent<Image>();
        FindObjectOfType<CG>().cgs_Slot[i] = buttonImage;
        FindObjectOfType<CG>().LoadPhoto();
    }
}
