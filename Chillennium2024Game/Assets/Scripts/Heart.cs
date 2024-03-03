using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heart : MonoBehaviour
{

    [SerializeField] SpriteRenderer heart1;
    [SerializeField] SpriteRenderer heart2;
    [SerializeField] SpriteRenderer heart3;
    [SerializeField] SpriteRenderer logo;

    [SerializeField] Sprite full_heart;
    [SerializeField] Sprite empty_heart;
    [SerializeField] Sprite half_heart;
    [SerializeField] Sprite blue_balls;
    [SerializeField] Sprite red_balls;

    [SerializeField] SpriteRenderer timer_frame;
    [SerializeField] SpriteRenderer timer;

    // Start is called before the first frame update
    void Start()
    {
        Color color = timer_frame.color;
        color.a = 0.0f;
        timer_frame.color = color;
        Color color2 = timer.color;
        color2.a = 0.0f;
        timer.color = color2;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.tombstone == Player.TombstoneType.radial)
        {
            logo.sprite = blue_balls;
            logo.gameObject.transform.localScale = new Vector3(.5f,.5f,.5f);
        }
        else
        {
            logo.sprite = red_balls;
            logo.gameObject.transform.localScale = new Vector3(1,1,1);

        }
        if (Player.life == Player.Life.Dead)
        {

            switch (Player.dead_health)
            {
                case 0:
                    heart1.color = new Color(0f, 0f, 0f, 0f);
                    heart2.sprite = empty_heart;
                    heart3.sprite = half_heart;
                    break;
                case 1:

                    heart1.color = new Color(0f, 0f, 0f, 0f);
                    heart2.sprite = half_heart;
                    heart3.sprite = half_heart;
                    break;
            }
        }
        else
        {
            heart1.color = new Color(1f, 1f, 1f, 1f);

            switch (Player.health)
            {
                case 0:
                    heart1.sprite = empty_heart;
                    heart2.sprite = empty_heart;
                    heart3.sprite = full_heart;
                    break;
                case 1:
                    heart1.sprite = empty_heart;
                    heart2.sprite = full_heart;
                    heart3.sprite = full_heart;
                    break;
                case 2:
                    heart1.sprite = full_heart;
                    heart2.sprite = full_heart;
                    heart3.sprite = full_heart;
                    break;
            }
        }
    }
}
