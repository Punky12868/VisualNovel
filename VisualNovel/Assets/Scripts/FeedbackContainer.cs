using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackContainer : MonoBehaviour
{
    public GameObject skip_feedback;
    public GameObject auto_feedback;
    public GameObject q_save_feedback;
    public GameObject q_load_feedback;

    public static bool skip;
    public static bool auto;
    bool qsave;
    bool qload;

    private void Update()
    {
        if (skip)
        {
            if (!skip_feedback.activeInHierarchy)
            {
                skip_feedback.SetActive(true);
            }
        }
        else
        {
            if (skip_feedback.activeInHierarchy)
            {
                skip_feedback.SetActive(false);
            }
        }

        if (auto)
        {
            if (!auto_feedback.activeInHierarchy)
            {
                auto_feedback.SetActive(true);
            }
        }
        else
        {
            if (auto_feedback.activeInHierarchy)
            {
                auto_feedback.SetActive(false);
            }
        }

        if (qsave)
        {
            if (!q_save_feedback.activeInHierarchy)
            {
                q_save_feedback.SetActive(true);
            }
        }
        else
        {
            if (q_save_feedback.activeInHierarchy)
            {
                q_save_feedback.SetActive(false);
            }
        }

        if (qload)
        {
            if (!q_load_feedback.activeInHierarchy)
            {
                q_load_feedback.SetActive(true);
            }
        }
        else
        {
            if (q_load_feedback.activeInHierarchy)
            {
                q_load_feedback.SetActive(false);
            }
        }
    }
    public void QsaveEvent(bool i)
    {
        if (i)
        {
            qsave = i;
        }
        else
        {
            qsave = i;
        }
    }
    public void QloadEvent(bool i)
    {
        if (i)
        {
            qload = i;
        }
        else
        {
            qload = i;
        }
    }
}
