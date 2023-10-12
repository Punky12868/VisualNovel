using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CatName : MonoBehaviour
{
    string cat;
    public void ChangeName(string s)
    {
        cat = s;
        FindObjectOfType<GameAssets>().catName = cat;
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
