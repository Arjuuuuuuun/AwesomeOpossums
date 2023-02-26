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
                    txt.text = "Your son's life has been untimely taken from you, \nForever upending your existence as you knew";
                    break;
                case 1:
                    sprender.sprite = scene2;
                    txt.text = "Refusing to accept this injustice as true, \nYou search far and deep for but a single clue";

                break;
                case 2:
                    sprender.sprite = scene3;
                    txt.text = "When an ancient mystic tome reveals the secret to life anew, \nFrom the corpse of a Pharaoh, a heart the seeker must hew";

                break;
                case 3:
                    sprender.sprite = scene4;
                    txt.text = "But to share a heart the Divine once grew, \nThe Pharaoh must test the worth of masters new...";

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
