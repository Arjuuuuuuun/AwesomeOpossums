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
        Debug.Log("start");
    }

    public void toggleOnSpectralLayer()
    {
        Debug.Log("On called");
        spriteRenderer.enabled = true;
    }

    public void toggleOffSpectralLayer()
    {
        Debug.Log("Off called");
        spriteRenderer.enabled = false;
    }
}
