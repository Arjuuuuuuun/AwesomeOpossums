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

    [SerializeField] SpriteRenderer timer;

    private float timeLeft;
    private int totalTime;

    private Vector3 timerStartingPosition = new Vector3(9.1f, 1.95f, 0f);


    // Start is called before the first frame update
    void Start()
    {
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

            Color color6 = timer.color;
            color6.a = 0.0f;
            timer.color = color6;

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

    IEnumerator Death(int time)
    {
        Color color2 = timer.color;
        color2.a = 1.0f;
        timer.color = color2;

        timeLeft = totalTime = time;
        timeLeft += 0.5f;
        for(int i = 0; i < time; ++i)
        {
            Debug.Log(timeLeft.ToString() + " : " + totalTime.ToString());
            timeLeft -= 1;

            UpdateTimer();
            yield return new WaitForSeconds(1);

        }

        Color color4 = timer.color;
        color2.a = 0.0f;
        timer.color = color4;
    }


    private void UpdateTimer()
    {
        float healthPercentage = timeLeft / totalTime;

        // Update the color of the health bar from green to red based on health percentage
        timer.color = Color.Lerp(Color.red, Color.green, healthPercentage);

        if (timeLeft <= 0)
        {
            // Set the alpha value of the color to make the image transparent
            Color currentColor = timer.color;
            currentColor.a = 0.0f; // Set the alpha to 50% (0.0 to 1.0, where 0 is fully transparent and 1 is fully opaque)
            timer.color = currentColor;
        }
        else
        {
            // Update the scale (width) of the health bar
            timer.gameObject.transform.localScale = new Vector3(healthPercentage * 2.5f, .3f, 1f);

            // Calculate the intended change in position
            /*float newPositionX = (healthPercentage - 1) / 2 * timerStartingPosition.x;

            // Add the intended change to the current local position
            timer.gameObject.transform.localPosition = new Vector3(timerStartingPosition.x + newPositionX, timerStartingPosition.y, timerStartingPosition.z);*/
        }
    }
}
