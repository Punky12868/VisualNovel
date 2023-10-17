using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ActiveOnGameplay : MonoBehaviour
{
    [SerializeField] GameObject target;
    public int targetScene;
    /*private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == targetScene && !target.activeInHierarchy)
        {
            target.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().buildIndex != targetScene && target.activeInHierarchy)
        {
            target.SetActive(false);
        }
    }*/
}
