using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_Rock : MonoBehaviour
{
    public GameObject ObjectToDestroy;
    System.Collections.IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(ObjectToDestroy);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Start the destruction coroutine
            StartCoroutine(DestroyAfterDelay(1f));
        }
    }
}