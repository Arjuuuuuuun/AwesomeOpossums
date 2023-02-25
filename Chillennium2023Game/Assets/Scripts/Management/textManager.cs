using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour
{


    public Text tutorial_text;
    public Button fox_buy_button;
    public Button rat_buy_button;
    public Button camel_buy_button;
    private bool is_fox_bought;
    private bool isWaiting;

    // Update is called once per frame
    void Update()
    {
        switch (HeadManager.instance.tutorial_counter)
        {
            case (1):
                tutorial_text.text = "Oh my! You are under attack!!! Buy a Fox buy clicking the button below!!!!";
                rat_buy_button.interactable = false;
                camel_buy_button.interactable = false;
                fox_buy_button.onClick.AddListener(FoxBought);
                if (is_fox_bought)
                {
                    ++HeadManager.instance.tutorial_counter;
                }
                break;

            case (2):
                tutorial_text.text = "Camels can block projectiles, use them to protect yourself!";
                rat_buy_button.interactable = true;
                camel_buy_button.interactable = true;
                StartCoroutine(Wait());
                break;
        }
    }

    void FoxBought()
    {
        is_fox_bought = true;
    }

    IEnumerator Wait()
    {
        if (isWaiting)
        {

        }
        else
        {
            isWaiting = true;
            yield return new WaitForSeconds(5);
            isWaiting = false;
            ++HeadManager.instance.tutorial_counter;
        }
    }
}
