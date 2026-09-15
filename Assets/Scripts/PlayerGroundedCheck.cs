using UnityEngine;

public class PlayerGroundedCheck : MonoBehaviour
{
    public static event System.Action playerIsGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) playerIsGrounded?.Invoke();
    }
}
