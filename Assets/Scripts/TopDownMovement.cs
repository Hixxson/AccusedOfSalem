using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;

    public RuntimeAnimatorController idleController;
    public RuntimeAnimatorController movementController;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isInputsFrozen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.runtimeAnimatorController = idleController;
    }

    void Update()
    {
        if (!isInputsFrozen)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector2 moveInput = new Vector2(moveHorizontal, moveVertical);
            moveInput.Normalize();

            rb2d.velocity = moveInput * moveSpeed;

            if (moveInput.magnitude > 0.1f)
            {
                if (animator.runtimeAnimatorController != movementController)
                    animator.runtimeAnimatorController = movementController;

                FlipSprite(moveInput.x);
            }
            else
            {
                if (animator.runtimeAnimatorController != idleController)
                    animator.runtimeAnimatorController = idleController;
            }
        }
    }

    void FlipSprite(float horizontalInput)
    {
        if (horizontalInput < 0)
            spriteRenderer.flipX = true;
        else if (horizontalInput > 0)
            spriteRenderer.flipX = false;
    }

    public void FreezePlayerInputs()
    {
        isInputsFrozen = true;
        // Optionally, you can add more logic here, like stopping animations or other actions.
    }

    public void UnfreezePlayerInputs()
    {
        isInputsFrozen = false;
    }
}




