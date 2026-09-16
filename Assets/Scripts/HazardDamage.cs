using UnityEngine;

public class HazardDamage : MonoBehaviour
{
    public static event System.Action<GameObject> playerDied;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameObject.tag.Contains(collision.gameObject.tag))
        {
            //collision.gameObject.SetActive(false);

            if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement test))
            {
                test.enabled = false;
            }

            collision.enabled = false;

            if (collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
            {
                rb.AddForceY(10f, ForceMode2D.Impulse);
                rb.gravityScale = 1;
            }

            playerDied.Invoke(collision.gameObject);
        }
    }
}
