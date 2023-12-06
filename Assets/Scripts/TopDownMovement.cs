using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb2d;

    public RuntimeAnimatorController idleController;
    public RuntimeAnimatorController movementController;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator.runtimeAnimatorController = idleController; // Start with the idle controller
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 moveInput = new Vector2(moveHorizontal, moveVertical);
        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;

        // Switch between idle and movement Animator Controllers based on movement
        if (moveInput.magnitude > 0.1f)
        {
            // Switch to the movement controller
            if (animator.runtimeAnimatorController != movementController)
                animator.runtimeAnimatorController = movementController;

            // Flip the sprite based on movement direction
            FlipSprite(moveInput.x);
        }
        else
        {
            // Switch to the idle controller
            if (animator.runtimeAnimatorController != idleController)
                animator.runtimeAnimatorController = idleController;
        }
    }

    void FlipSprite(float horizontalInput)
    {
        if (horizontalInput < 0)
            spriteRenderer.flipX = true; // Flip the sprite when moving left
        else if (horizontalInput > 0)
            spriteRenderer.flipX = false; // Unflip the sprite when moving right
    }
}



