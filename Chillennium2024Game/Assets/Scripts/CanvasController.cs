using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private VideoPlayer vp;
    [SerializeField] private Button b1;
    [SerializeField] private Button b2;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Video");
        b1.gameObject.transform.position = new Vector3(10000, 10000, 10000);

        b2.gameObject.transform.position = new Vector3(10000, 10000, 10000);

        background.transform.position = new Vector3(10000, 10000, 10000);
        sr.gameObject.transform.position = new Vector3(10000, 10000, 10000);
    }

    IEnumerator Video()
    {
        yield return new WaitForSeconds(1);
        vp.Play();
        b1.interactable = false;
        b2.interactable = false;
        yield return new WaitForSeconds(46);
        vp.gameObject.transform.position = new Vector3(10000, 10000, 10000);
        b1.gameObject.transform.position = new Vector3(0, -1, 0);
        b2.gameObject.transform.position = new Vector3(0, 0, 0);
        background.transform.position = new Vector3(0, 0, 0);
        sr.gameObject.transform.position = new Vector3(-.5f, 2, 0);

        b1.interactable = true;
        b2.interactable = true;
    }
}
