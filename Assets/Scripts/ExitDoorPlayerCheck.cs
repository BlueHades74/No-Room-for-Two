using UnityEngine;

public class ExitDoorPlayerCheck : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color color;
    private bool flashingDoors = false;

    public static event System.Action playerEntered;
    public static event System.Action playerExited;

    private void Awake()
    {
        color = Color.white;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        ExitDoorSceneSwap.bothPlayersInExits += FlashDoors;
    }

    private void OnDisable()
    {
        ExitDoorSceneSwap.bothPlayersInExits -= FlashDoors;
    }

    private void Update()
    {
        if (flashingDoors)
        {
            color.g = Mathf.PingPong(Time.time * 2f, 1f);
            spriteRenderer.color = color;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

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

    private void FlashDoors(bool blink)
    {
        flashingDoors = blink;
    }
}
