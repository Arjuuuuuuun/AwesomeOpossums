using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ModeToggler : MonoBehaviour
{
    [SerializeField] private Sprite Physical;
    [SerializeField] private Sprite Ghost;
    private float cooldownTime;
    private Image image;
    private PlayerMovement player;
    private bool statePrev;

    void Start()
    {
        image = GetComponent<Image>();
        image.sprite = Physical;

        player = FindObjectOfType<PlayerMovement>();
        statePrev = player.spectralOn;
        cooldownTime = player.cooldownTime;

        if (player == null)
        {
            Debug.LogError("Player object with PlayerMovement script not found!");
        }

        image.type = Image.Type.Filled;
        image.fillMethod = Image.FillMethod.Radial360; 
    }

    void Update()
    {
        image.sprite = player.spectralOn ? Ghost : Physical;

        if (player.spectralOn != statePrev && !player.spectralOn)
        {
            StartCoroutine(Cooldown(cooldownTime));
        }

        statePrev = player.spectralOn;

        if(!player.canSwap)
        {
            image.color = Color.gray;
        }
        else
        {
            image.color = Color.white;
        }
    }

    IEnumerator Cooldown(float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            image.fillAmount = elapsedTime / duration; // Gradually increase fill
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.fillAmount = 1f; // Fully present
    }
}
