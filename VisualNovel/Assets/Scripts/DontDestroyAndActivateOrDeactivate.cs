using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAndActivateOrDeactivate : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Menú");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
