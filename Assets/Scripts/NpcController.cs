using UnityEngine;

public class NpcController : MonoBehaviour
{
    public float moveSpeed = 5f; 
    private bool isMoving = true;

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


        StartCoroutine(DestroyAfterDelay(2f));
    }
}






