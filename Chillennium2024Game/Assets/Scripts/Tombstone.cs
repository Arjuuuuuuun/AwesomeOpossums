using System.Collections;
using UnityEngine;

abstract public class Tombstone : MonoBehaviour
{

    [SerializeField] protected enum TombstoneState {notActive, Active };
    protected TombstoneState state;
    [SerializeField] protected float tombstoneAwakeTime;
    bool playerNear;



    protected SpriteRenderer spriteRenderer;
   
    void Start()
    {
        state = TombstoneState.notActive;
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        switch (state) {
            case TombstoneState.notActive:
                spriteRenderer.color = Color.gray;
                if (playerNear && Input.GetKeyDown(KeyCode.Space))
                {
                   StartCoroutine(ActiveTimer());
                }
                break;
            case TombstoneState.Active:
                Activate();
                spriteRenderer.color = Color.blue;
                break;   
        }
    }
    virtual protected void Activate()
    {
        return;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerNear = false;
        }
    }

    IEnumerator ActiveTimer()
    {
        state = TombstoneState.Active;
        yield return new WaitForSeconds(tombstoneAwakeTime);
        state = TombstoneState.notActive;
    }


}
