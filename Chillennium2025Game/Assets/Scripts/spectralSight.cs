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
            if (distanceToPlayer < appearInnerRadius)
            {
                new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else if(distanceToPlayer < appearOuterRadius)
            {
                float scratch = distanceToPlayer - appearOuterRadius;
                new Color(1.0f, 1.0f, 1.0f,scratch / (appearOuterRadius - appearInnerRadius));
            }
            else
            {
                spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            }
        }
    }

    public void toggleOnSpectralLayer()
    {
        inSight = true;
        spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void toggleOffSpectralLayer()
    {
        inSight = false;
        spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }
}
