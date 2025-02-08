using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] GameObject NormalThemeObject;
    [SerializeField] GameObject SpectralThemeObject;
    AudioSource NormalTheme;
    AudioSource SpectralTheme;
    PlayerMovement playerMovement;
    bool isNormalModePlaying;
    // Start is called before the first frame update
    void Awake()
    {
        NormalTheme = NormalThemeObject.GetComponent<AudioSource>();
        SpectralTheme = SpectralThemeObject.GetComponent<AudioSource>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        NormalTheme.Play();
        SpectralTheme.volume = 0.0f;
        isNormalModePlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.spectralOn && isNormalModePlaying)
        {
            isNormalModePlaying = false;
            StartCoroutine("fadeOut", NormalTheme);
            StartCoroutine("fadeIn", SpectralTheme);

        }
        else if (!playerMovement.spectralOn && !isNormalModePlaying)
        {
            isNormalModePlaying = true;
            StartCoroutine("fadeIn", NormalTheme);
            StartCoroutine("fadeOut", SpectralTheme);
        }
    }

    IEnumerator fadeIn(AudioSource clip)
    {
        for (int i = 0; i < 10; ++i)
        {
            clip.volume += 0.07f;
            yield return new WaitForSeconds(.03f);
        }
        clip.volume = 0.7f;
    }

    IEnumerator fadeOut(AudioSource clip)
    {
        for (int i = 0; i < 10; ++i)
        {
            clip.volume -= 0.07f;
            yield return new WaitForSeconds(.03f);
        }
        clip.volume = 0.0f;
    }
}
