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
        spriteRenderer.enabled = true;
        spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }

    private void Update()
    {
        if (!inSight)
        {
            float distanceToPlayer = Vector2.Distance(FindAnyObjectByType<PlayerMovement>().gameObject.transform.position,this.transform.position);
            if (distanceToPlayer > appearOuterRadius)
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
