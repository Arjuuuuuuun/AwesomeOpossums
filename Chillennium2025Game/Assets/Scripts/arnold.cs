using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arnold : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    [SerializeField] float animationTime;
    float elaspedTime = 0.0f;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        while (elaspedTime < animationTime)
        {
            transform.localScale = new Vector3((1.0f + elaspedTime), (1.0f + elaspedTime), 1.0f);
            spriteRenderer.color = new Color(0.0f, 0.0f, 0.0f, elaspedTime / animationTime);
            elaspedTime += Time.deltaTime;
        }
    }
}
