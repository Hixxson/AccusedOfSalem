using UnityEngine;

public class NpcController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isMoving = true;
    private bool hasCollidedWithPlayer = false;

    void Update()
    {
        if (isMoving)
        {
            MoveNpcDown();
        }
    }

    void MoveNpcDown()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    System.Collections.IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    public void ResumeMoving()
    {
        isMoving = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasCollidedWithPlayer)
        {
            // Trigger the event to unfreeze player movement
            EventManager.TriggerFreezePlayer(false);

            // Stop NPC movement
            StopMoving();


            // Set a flag to remember the collision
            hasCollidedWithPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Resume NPC movement
            ResumeMoving();

            // Set a flag to remember the exit
            hasCollidedWithPlayer = false;

            // Start the destruction coroutine
            StartCoroutine(DestroyAfterDelay(2f));
        }
    }
}
