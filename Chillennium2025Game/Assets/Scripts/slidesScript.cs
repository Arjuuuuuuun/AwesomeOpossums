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
    [SerializeField] private Image text;
    [SerializeField] private Sprite[] textSlides;
    [SerializeField] private Image spaceToContinue;


    private int currentSlideIndex = 0;
    private RectTransform rectTransform;
    private float screenWidth;
    private float screenHeight;

    void Start()
    {
        spaceToContinue.color = new Color(0,0,0,0);

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
        while (currentSlideIndex <= slides.Length)
        {
            if (currentSlideIndex == 0)
            {
                // First slide animation: scroll from right to left
                float elapsedTime = 0f;
                Vector2 startPos = new Vector2(rectTransform.sizeDelta.x / 2 - screenWidth / 2, 0); // Start at the right edge
                Vector2 endPos = new Vector2(-rectTransform.sizeDelta.x / 2 + screenWidth / 2, 0); // Move to the left edge

                rectTransform.anchoredPosition = startPos;

                while (elapsedTime < firstSlideScrollTime)
                {
                    if(elapsedTime < firstSlideScrollTime / 4)
                    {
                        text.sprite = textSlides[0];
                    }else if(elapsedTime < firstSlideScrollTime / 2)
                    {
                        text.sprite = textSlides[1];
                    } else if(elapsedTime < firstSlideScrollTime *3 / 4)
                    {
                        text.sprite = textSlides[2];
                    }
                    else
                    {
                        text.sprite = textSlides[3];
                    }

                    if (Input.GetKeyDown(KeyCode.Space)) break;

                    elapsedTime += Time.deltaTime;
                    rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, elapsedTime / firstSlideScrollTime);
                    yield return null;
                }
                text.color = new Color(0, 0, 0, 0);
                rectTransform.anchoredPosition = endPos;
                currentSlideIndex++; // Move to the next slide after first
            }
            else
            {
                // Display subsequent slides
                yield return StartCoroutine(DisplaySlide());

                // Wait for spacebar to proceed
                while (!Input.GetKeyDown(KeyCode.Space))
                {
                    spaceToContinue.color = new Color(1, 1, 1, 1);

                    yield return null; // Waiting for spacebar press
                }

                currentSlideIndex++; // Move to the next slide
            }
        }
        // Enable buttons and destroy object after last slide
        button1.interactable = true;
        button2.interactable = true;
        spaceToContinue.color = new Color(0, 0, 0, 0);
        // Destroy GameObject after the final slide
        Destroy(gameObject);
    }

    private IEnumerator DisplaySlide()
    {
        // Display current slide for the minimum time or until space is pressed
        float elapsedTime = 0f;
        while (elapsedTime < minSlideTime || !(Input.GetKeyDown(KeyCode.Space)))
        {
            if(elapsedTime < minSlideTime)
            {
                spaceToContinue.color = new Color(0,0,0,0);
            }
            else
            {
                spaceToContinue.color = new Color(1, 1, 1, 1);
            }
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Move to the next slide setup
        if (currentSlideIndex < slides.Length)
        {
            SetupSlide(slides[currentSlideIndex]);
        }
        
           
        
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

}
