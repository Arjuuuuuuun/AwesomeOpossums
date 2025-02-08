using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    // public Animator animator; // Reference to the Animator component
    // public string destructionAnimationName = "DestructionSequence"; // Animation name
    private SpriteRenderer renderer;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        color = renderer.color;
        // Make sure the animator is assigned
        /*if (animator == null)
        {
            animator = GetComponent<Animator>();
        }*/
    }

    // This function is called when the message "Initiate Destruction Sequence" is received
    void InitiateDestructionSequence()
    {


        /*// Play the destruction animation
        animator.SetTrigger(destructionAnimationName);*/

        StartCoroutine(DestroyAfterAnimation());
        
    }

    // Coroutine to wait for animation to finish and then destroy the door
    IEnumerator DestroyAfterAnimation()
    {
        float opacity = 1f;

        while (opacity > 0f)
        {
            renderer.color = new Color(color.r, color.g, color.b, opacity / 2);
            opacity -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        Destroy(gameObject);
    }
}
