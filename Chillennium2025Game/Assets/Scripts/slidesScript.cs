using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlideScript : MonoBehaviour
{
    [SerializeField] private Image slideImage;       // Reference to the UI Image
    [SerializeField] private Sprite[] slides;        // Array of slides (sprites)
    [SerializeField] private float firstSlideScrollTime = 5f; // Time to scroll first slide
    [SerializeField] private float minSlideTime = 2f; // Minimum time per slide
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;

    private int currentSlideIndex = 0;
    private RectTransform rectTransform;
    private float screenWidth;
    private float screenHeight;

    void Start()
    {
        button1.interactable = false;
        button2.interactable = false;
        rectTransform = slideImage.rectTransform;
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        if (slides.Length > 0)
        {
            SetupSlide(slides[0]);
            StartCoroutine(ShowSlides());
        }
    }

    private IEnumerator ShowSlides()
    {
        while (currentSlideIndex < slides.Length)
        {
            if (currentSlideIndex == 0)
            {
                yield return StartCoroutine(ScrollFirstSlide());
            }
            else
            {
                ResetSlidePosition();
                yield return StartCoroutine(DisplaySlide());
            }

            currentSlideIndex++;
        }

        // Destroy GameObject after the final slide
        Destroy(gameObject);
    }

    private void SetupSlide(Sprite sprite)
    {
        slideImage.sprite = sprite;

        float imageAspect = (float)sprite.texture.width / sprite.texture.height;
        float screenAspect = screenWidth / screenHeight;

        if (imageAspect > screenAspect)
        {
            // Fit height, adjust width
            rectTransform.sizeDelta = new Vector2(screenHeight * imageAspect, screenHeight);
        }
        else
        {
            // Fit width, adjust height
            rectTransform.sizeDelta = new Vector2(screenWidth, screenWidth / imageAspect);
        }

        // Position left edge of image at the left edge of the screen
        rectTransform.anchoredPosition = new Vector2(-rectTransform.sizeDelta.x / 2 + screenWidth / 2, 0);
    }
    private IEnumerator ScrollFirstSlide()
    {
        float elapsedTime = 0f;
        Vector2 startPos = new Vector2(rectTransform.sizeDelta.x / 2 - screenWidth / 2, 0); // Start at the right edge
        Vector2 endPos = new Vector2(-rectTransform.sizeDelta.x / 2 + screenWidth / 2, 0); // Move to the left edge

        rectTransform.anchoredPosition = startPos;

        while (elapsedTime < firstSlideScrollTime)
        {
            if (Input.GetKeyDown(KeyCode.Space)) break;

            elapsedTime += Time.deltaTime;
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsedTime / firstSlideScrollTime);
            yield return null;
        }

        rectTransform.anchoredPosition = endPos;
    }


    private void ResetSlidePosition()
    {
        rectTransform.anchoredPosition = new Vector2(-rectTransform.sizeDelta.x / 2 + screenWidth / 2, 0);
    }

    private IEnumerator DisplaySlide()
    {
        float elapsedTime = 0f;
        while (elapsedTime < minSlideTime || !Input.GetKeyDown(KeyCode.Space))
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (currentSlideIndex + 1 < slides.Length)
        {
            SetupSlide(slides[currentSlideIndex + 1]);
        }
        else
        {

            button1.interactable = true;
            button2.interactable = true;
            Destroy(gameObject); // Destroy after the final slide
        }
    }
}
