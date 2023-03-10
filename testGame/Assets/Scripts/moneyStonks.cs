using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneyStonks : MonoBehaviour
{

    int worker_level;
    int money;
    int max_money;
    int money_generation;
    int worker_price;
    int reveille_price;
    int aggie_engineer_price;
    int jimbo_fisher_price;

    public Button worker_upgrade_button;
    public Button reveille_buy_button;
    public Button aggie_engineer_buy_button;
    public Button jimbo_fisher_buy_button;
    public Text worker_upgrade_button_text;
    public Text reveille_buy_button_text;
    public Text aggie_engineer_buy_button_text;
    public Text jimbo_fisher_buy_button_text;
    public Text money_display_text;


    // Start is called before the first frame update
    void Start()
    {
        worker_level = 1;
        money = 0;
        max_money = 2000;
        money_generation = 5;
        worker_price = 800;
        reveille_price = 1300;
        aggie_engineer_price = 550;
        jimbo_fisher_price = 3000;

        reveille_buy_button_text.text = '$' + reveille_price.ToString();
        jimbo_fisher_buy_button_text.text = '$' + jimbo_fisher_price.ToString();
        aggie_engineer_buy_button_text.text = '$' + aggie_engineer_price.ToString();
        worker_upgrade_button_text.text = '$' + worker_price.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (money <= max_money - money_generation)
        {
            money += money_generation;
        }
        else
        {
            money = max_money;
        }

        money_display_text.text = '$' + money.ToString() + '/' + max_money.ToString();
    }

    public void onAggieEngineerBuy()
    {
        if (money < aggie_engineer_price)
        {
            return;
        }
        money -= aggie_engineer_price;
        //spawn aggie engineer
    }

    public void onReveilleBuy()
    {
        if (money < reveille_price)
        {
            return;
        }
        money -= reveille_price;
        //spawn reveille
    }

    public void onJimboFisherBuy()
    {
        if (money < jimbo_fisher_price)
        {
            return;
        }
        money -= jimbo_fisher_price;
        //spawn jimbo fisher
    }

    public void onWorkerUpgrade()
    {
        if (money < worker_price)
        {
            return;
        }
        money -= worker_price;

        switch(worker_level)
        {
            case 1:
                worker_level = 2;
                money_generation = 7;
                max_money = 2500;
                worker_price = 1000;
                worker_upgrade_button_text.text = '$' + worker_price.ToString();
                break;

            case 2:
                worker_level = 3;
                money_generation = 9;
                max_money = 2900;
                worker_price = 1200;
                worker_upgrade_button_text.text = '$' + worker_price.ToString();
                break;

            case 3:
                worker_level = 4;
                money_generation = 10;
                max_money = 3300;
                worker_price = 1500;
                worker_upgrade_button_text.text = '$' + worker_price.ToString();
                break;

            case 4:
                worker_level = 5;
                money_generation = 11;
                max_money = 3600;
                worker_price = 1900;
                worker_upgrade_button_text.text = '$' + worker_price.ToString();
                break;

            case 5:
                worker_level = 6;
                money_generation = 12;
                max_money = 3800;
                worker_upgrade_button.interactable = false;
                worker_upgrade_button_text.text = "MAX LEVEL ACQUIRED :)!";
                break;
        }
    }
}
