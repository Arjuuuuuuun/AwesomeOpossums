using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Son : MonoBehaviour
{
    Animator anime;
    SpriteRenderer sprender;
    
    private void Awake()
    {
        anime = GetComponent<Animator>();

        anime.SetBool("funnyDeathBool", false);
        sprender = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void takeDamage(int val)
    {
        GameObject.Find("GameManager").SendMessage("TakeSonDamage", val);          
        StartCoroutine(Damnage());  
    }
    void remoteCallFunnyDamage()
    {
        StartCoroutine(Damnage());
    }
    IEnumerator Damnage()
    {
        anime.SetBool("funnyDeathBool", true);
        yield return new WaitForSeconds(.5f);
        anime.SetBool("funnyDeathBool", false);

    }
}
