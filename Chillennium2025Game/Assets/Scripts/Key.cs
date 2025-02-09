using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour
{
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.03f;
    public float bounceHeight = 2f;
    public float fallSpeed = 2f;

    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private bool isClaimed = false;
    private Vector3 originalScale;
    private Color originalColor;
    private float fadeDuration = 0.5f;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (!isClaimed)
        {
            // Pulsing effect
            float scaleFactor = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
            transform.localScale = originalScale * scaleFactor;

            // Adjust brightness (grayer when smaller, brighter when larger)
            float brightness = Mathf.Lerp(0.5f, 1f, scaleFactor);
            spriteRenderer.color = new Color(brightness, brightness, brightness, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isClaimed)
        {
            StartCoroutine(Claimed());
        }
    }
    private IEnumerator Claimed()
    {
        isClaimed = true;
        boxCollider.enabled = false; // Disable collider

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // Get the sprite renderer
        if (spriteRenderer == null) yield break; // Exit if no sprite renderer

        float elapsedTime = 0f;
        Color startColor = spriteRenderer.color;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration); // Gradual fade to transparent
            spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f); // Ensure fully transparent
        Destroy(gameObject);
    }


}
