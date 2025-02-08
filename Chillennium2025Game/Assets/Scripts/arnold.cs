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
        StartCoroutine(jumpScare());
    }

    IEnumerator jumpScare()
    {
        while (elaspedTime < animationTime)
        {
            elaspedTime += 0.1f;
            transform.localScale = new Vector3(elaspedTime/ animationTime, elaspedTime / animationTime, 1.0f);
            spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, elaspedTime / animationTime);
            yield return new WaitForSeconds(0.01f);
        }
    } 
}
