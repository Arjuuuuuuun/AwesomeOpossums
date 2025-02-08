using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arnold : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    audioManager audioManager;

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
        audioManager = FindObjectOfType<audioManager>();
        audioManager.SendMessage("StopAllThemes");
        Time.timeScale = 0.000001f;
        while (elaspedTime < animationTime)
        {
            elaspedTime += 0.1f;
            transform.localScale = new Vector3(elaspedTime/ animationTime, elaspedTime / animationTime, 1.0f);
            spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, elaspedTime / animationTime);
            yield return new WaitForSeconds(0.00000001f);
        }
        yield return new WaitForSeconds(0.000002f);
        Time.timeScale = 1;
        SceneManager.LoadScene("GameOverScene");
    } 
}
