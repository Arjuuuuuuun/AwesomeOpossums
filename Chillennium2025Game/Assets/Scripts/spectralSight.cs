using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spectralSight : MonoBehaviour
{ 
    SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void toggleOnSpectralLayer()
    {
        spriteRenderer.enabled = true;
    }

    public void toggleOffSpectralLayer()
    {
        spriteRenderer.enabled = false;
    }
}
