using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spectralSight : MonoBehaviour
{ 
    SpriteRenderer spriteRenderer;
    [SerializeField] float appearOuterRadius;
    [SerializeField] float appearInnerRadius;
    bool inSight = false;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (!inSight)
        {
            if(Vector2.Distance(FindAnyObjectByType<PlayerMovement>().gameObject.transform.position,this.transform.position) > appearOuterRadius)
            {

            }
        }
    }

    public void toggleOnSpectralLayer()
    {
        inSight = true;
        spriteRenderer.enabled = true;
    }

    public void toggleOffSpectralLayer()
    {
        inSight = false;
        spriteRenderer.enabled = false;
    }
}
