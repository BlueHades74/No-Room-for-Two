using UnityEngine;

public class ExitDoorPlayerCheck : MonoBehaviour
{
    public static event System.Action playerEntered;
    public static event System.Action playerExited;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // a player entered, let the others know
        if (collision.CompareTag("Blue") || collision.CompareTag("Red")) playerEntered?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // a player exited, let the others know
        if (collision.CompareTag("Blue") || collision.CompareTag("Red")) playerExited?.Invoke();
    }
}
