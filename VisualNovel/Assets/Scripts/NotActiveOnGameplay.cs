using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NotActiveOnGameplay : MonoBehaviour
{
    [SerializeField] GameObject target;
    public int targetScene;
    public bool notActivateAgain;
    private void Update()
    {
        if (!notActivateAgain)
        {
            if (SceneManager.GetActiveScene().buildIndex == targetScene && !target.activeInHierarchy)
            {
                target.SetActive(true);
            }
            else if (SceneManager.GetActiveScene().buildIndex != targetScene && target.activeInHierarchy)
            {
                target.SetActive(false);
            }
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex == targetScene && target.activeInHierarchy)
            {
                target.SetActive(false);
            }
        }
    }
    public void ActivateTarget()
    {
        target.SetActive(true);
    }
}
