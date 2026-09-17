using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveInput;
    private Rigidbody2D rb;
    private int maxJumpCount = 2;
    private int jumpCount;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpPower = 8f;

    private void OnEnable()
    {
        PlayerGroundedCheck.playerIsGrounded += ResetJumpCount;
    }

    private void OnDisable()
    {
        PlayerGroundedCheck.playerIsGrounded -= ResetJumpCount;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (jumpCount > 0)
        {
            rb.linearVelocityY = jumpPower;
            // don't remove from jumpCount past initial button press
            if (!context.performed) return;
            jumpCount--;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = moveInput * moveSpeed;
    }

    private void ResetJumpCount()
    {
        jumpCount = maxJumpCount;
    }
}
