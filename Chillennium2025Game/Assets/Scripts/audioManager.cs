using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] GameObject NormalThemeObject;
    [SerializeField] GameObject SpectralThemeObject;
    [SerializeField] GameObject spectralModeOnObject;
    [SerializeField] GameObject spectralModeOffObject;
    [SerializeField] GameObject jumpscareObject;
    [SerializeField] GameObject keySoundObject;
    AudioSource NormalTheme;
    AudioSource SpectralTheme;
    AudioSource spectralModeOn;
    AudioSource spectralModeOff;
    AudioSource jumpscare;
    AudioSource keySound;
    PlayerMovement playerMovement;
    bool isNormalModePlaying;
    // Start is called before the first frame update
    void Awake()
    {
        NormalTheme = NormalThemeObject.GetComponent<AudioSource>();
        SpectralTheme = SpectralThemeObject.GetComponent<AudioSource>();
        spectralModeOn = spectralModeOnObject.GetComponent<AudioSource>();
        spectralModeOff = spectralModeOffObject.GetComponent<AudioSource>();
        jumpscare = jumpscareObject.GetComponent<AudioSource>();
        keySound = keySoundObject.GetComponent<AudioSource>();
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
            spectralModeOn.Play();
            StartCoroutine("fadeOut", NormalTheme);
            StartCoroutine("fadeIn", SpectralTheme);

        }
        else if (!playerMovement.spectralOn && !isNormalModePlaying)
        {
            isNormalModePlaying = true;
            spectralModeOff.Play();
            StartCoroutine("fadeIn", NormalTheme);
            StartCoroutine("fadeOut", SpectralTheme);
        }
    }

    public void playKeySounds()
    {
        keySound.Play();
    }

    public void StopAllThemes()
    {
        jumpscare.Play();
        SpectralTheme.volume = 0.0f;
        NormalTheme.volume = 0.0f;
    }

    public void raiseHeartbeat()
    {

    }

    public void lowerHeartbeat()
    {

    }
    IEnumerator fadeIn(AudioSource clip)
    {
        for (int i = 0; i < 10; ++i)
        {
            clip.volume += 0.05f;
            yield return new WaitForSeconds(.03f);
        }
        clip.volume = 0.5f;
    }

    IEnumerator fadeOut(AudioSource clip)
    {
        for (int i = 0; i < 10; ++i)
        {
            clip.volume -= 0.05f;
            yield return new WaitForSeconds(.03f);
        }
        clip.volume = 0.0f;
    }
}
