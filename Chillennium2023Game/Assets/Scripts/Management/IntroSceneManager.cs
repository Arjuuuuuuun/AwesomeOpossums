using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSceneManager : MonoBehaviour
{
    [SerializeField] Sprite scene1;
    [SerializeField] Sprite scene2;
    [SerializeField] Sprite scene3;
    [SerializeField] Sprite scene4;
    [SerializeField] GameObject Butt1;
    [SerializeField] GameObject Butt2;
    public Text txt;
    public Text dongle;
    SpriteRenderer sprender;
    int introScene;
    bool waiting;
    
    // Start is called before the first frame update
    void Start()
    {
        sprender = GetComponent<SpriteRenderer>();
        sprender.sortingLayerName = "Default";
        waiting = false;
        sprender.sprite = scene1;
        introScene = 0;
        Butt1.transform.position = new Vector3(10000, 10000, 10000);
        Butt2.transform.position = new Vector3(10000, 10000, 10000);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (!waiting)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                introScene += 1;
            }
        }
            switch (introScene)
            {
                case 0:
                    sprender.sprite = scene1;
                    txt.text = "intro1";
                    break;
                case 1:
                    sprender.sprite = scene2;
                    txt.text = "intro2";

                break;
                case 2:
                    sprender.sprite = scene3;
                    txt.text = "intro3";

                break;
                case 3:
                    sprender.sprite = scene4;
                    txt.text = "intro4";

                break;
                default:
                    sprender.transform.position = new Vector3(10000, 10000, 10000);
                    Butt1.transform.position = new Vector3(0 , 3, 0);
                    Butt2.transform.position = new Vector3(0, -3, 0); 
                    waiting = true;
                    txt.text = "";
                sprender.sortingLayerName = "Background";
                    break;
            
        }
    }
}
