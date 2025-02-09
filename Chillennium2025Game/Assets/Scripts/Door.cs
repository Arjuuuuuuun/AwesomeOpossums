using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Transform trans;

    private enum Direction { Up, Down, Left, Right }
    [SerializeField] private Direction dir;

    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Function to trigger destruction sequence
    void InitiateDestructionSequence()
    {
        StartCoroutine(DestroyAfterAnimation());
    }

    // Coroutine for moving the door and destroying it
    IEnumerator DestroyAfterAnimation()
    {
        float duration = 2f; // Move over 2 seconds
        float elapsedTime = 0f;
        Vector3 startPos = trans.localPosition;
        Vector3 targetPos = startPos;

        // Determine movement direction
        switch (dir)
        {
            case Direction.Up:
                targetPos += Vector3.up;
                break;
            case Direction.Down:
                targetPos += Vector3.down;
                break;
            case Direction.Left:
                targetPos += Vector3.left;
                break;
            case Direction.Right:
                targetPos += Vector3.right;
                break;
        }

        // Move the door gradually
        while (elapsedTime < duration)
        {
            trans.localPosition = Vector3.Lerp(startPos, targetPos, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;  // Wait for the next frame
        }

        trans.localPosition = targetPos;  // Ensure exact final position
        Destroy(gameObject);  // Destroy the door
    }
}
