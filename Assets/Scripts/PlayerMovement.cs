using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float moveInput;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpPower = 8f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
        Debug.Log(moveInput);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // need to put a trigger for players being grounded then check for jump
        rb.linearVelocityY = jumpPower;
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = moveInput * moveSpeed;
    }
}
