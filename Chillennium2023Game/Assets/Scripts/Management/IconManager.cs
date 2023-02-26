using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconManager : MonoBehaviour
{

    public GameObject bear;
    public GameObject fox;
    public GameObject elepant;
    public GameObject fire;
    public GameObject money;
    private bool is_moved1;
    private bool is_moved2;
    private bool is_moved3;
    private bool is_moved4;
    private bool is_moved5;

    private void Update()
    {
        if (HeadManager.instance.is_fox_active)
        {
            if (!is_moved1)
            {
                is_moved1 = true;
                bear.transform.position = new Vector3(bear.transform.position.x, bear.transform.position.y + 4.5f, bear.transform.position.z);
            }
        }

        if (HeadManager.instance.is_powerup_active)
        {
            if (!is_moved2)
            {
                is_moved2 = true;
                fire.transform.position = new Vector3(fire.transform.position.x, fire.transform.position.y + 4.5f, fire.transform.position.z);
            }
        }

        if (HeadManager.instance.is_powerup_active)
        {
            if (!is_moved3)
            {
                is_moved3 = true;
                money.transform.position = new Vector3(money.transform.position.x, money.transform.position.y + 4.5f, money.transform.position.z);
            }
        }

        if (HeadManager.instance.is_camel_active)
        {
            if (!is_moved4)
            {
                is_moved4 = true;
                elepant.transform.position = new Vector3(elepant.transform.position.x, elepant.transform.position.y + 4.5f, elepant.transform.position.z);
            }
        }

        if (HeadManager.instance.is_rat_active)
        {
            if (!is_moved5)
            {
                is_moved5 = true;
                fox.transform.position = new Vector3(fox.transform.position.x, fox.transform.position.y + 4.5f, fox.transform.position.z);
            }
        }

    }
}
