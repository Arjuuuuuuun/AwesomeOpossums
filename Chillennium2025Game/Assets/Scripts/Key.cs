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

    IEnumerator Claimed()
    {
        isClaimed = true;
        boxCollider.enabled = false; // Disable collider

        float elapsedTime = 0f;
        Vector3 startPos = transform.position;
        Vector3 peakPos = startPos + Vector3.up * bounceHeight;

        // Move Up (Bounce)
        while (elapsedTime < 0.3f)
        {
            transform.position = Vector3.Lerp(startPos, peakPos, elapsedTime / 0.3f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Fall Down
        while (transform.position.y > -10f)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}
