using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPainting : MonoBehaviour
{
    [SerializeField] Transform painting;

    [SerializeField] Transform opened;
    [SerializeField] Transform closed;

    [SerializeField] GameObject loadPanel;
    [SerializeField] GameObject galleryPanel;

    [SerializeField] float lerpSpeed;
    [SerializeField] float margen;

    public bool load;
    public bool gallery;
    private void FixedUpdate()
    {
        
    }
}
