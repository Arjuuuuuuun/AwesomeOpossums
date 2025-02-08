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

        float duration = 2f; // Time for both up and down
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;
        Vector3 peakPos = startPos + Vector3.up * bounceHeight;
        Vector3 fallPos = new Vector3(startPos.x, -10f, startPos.z); // Target off-screen position

        // Calculate the velocity based on the distance and time
        float upwardDistance = Mathf.Abs(peakPos.y - startPos.y);
        float velocityUp = upwardDistance / (duration/4); // Velocity for upward movement

        // Move Up (Bounce)
        while (elapsedTime < duration/4)
        {
            float distanceMoved = velocityUp * elapsedTime;
            transform.position = new Vector3(startPos.x, startPos.y + distanceMoved, startPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = peakPos; // Ensure exact position
        elapsedTime = 0f; // Reset time for falling

        float velocityDown = velocityUp;

        // Move Down (Fall)
        while (elapsedTime < duration)
        {
            float distanceMoved = velocityDown * elapsedTime;
            transform.position = new Vector3(peakPos.x, peakPos.y - distanceMoved, peakPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = fallPos; // Ensure exact position
        Destroy(gameObject);
    }


}
