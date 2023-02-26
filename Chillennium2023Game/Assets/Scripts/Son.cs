using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Son : MonoBehaviour
{
    Animator anime;
    SpriteRenderer sprender;
    [SerializeField] Sprite spir;
    [SerializeField] Sprite spirt;
    private void Awake()
    {
        sprender = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
    }
    // Update is called once per frame
    void takeDamage(int val)
    {
        GameObject.Find("GameManager").SendMessage("TakeSonDamage", val);  
        anime.StopPlayback();
        sprender.sprite = spir;
        sprender.sortingOrder = 2;
        StartCoroutine("Damnage");  
    }
    IEnumerable Damnage()
    {
        yield return new WaitForSeconds(.5f);
        sprender.sprite = spirt;
        sprender.sortingOrder = 1;

        anime.StartPlayback();
    }
}
