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
    bool can_upgrade;


    // Start is called before the first frame update
    void Start()
    {
        worker_level = 1;
        money = 0;
        max_money = 400;
        money_generation = 1;
        worker_price = 40;
        can_upgrade = true;
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

        Debug.Log(money);
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
                money_generation = 3;
                max_money = 500;
                worker_price = 60;
                break;
            case 2:
                worker_level = 3;
                money_generation = 5;
                max_money = 580;
                worker_price = 80;
                break;
            case 3:
                worker_level = 4;
                money_generation = 6;
                max_money = 660;
                worker_price = 100;
                break;
            case 4:
                worker_level = 5;
                money_generation = 7;
                max_money = 720;
                worker_price = 120;
                break;
            case 5:
                worker_level = 6;
                money_generation = 8;
                max_money = 760;
                can_upgrade = false;
                break;
        }
    }
}
