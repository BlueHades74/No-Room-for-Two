using UnityEngine;

public class HazardDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!collision.gameObject.CompareTag(this.gameObject.tag))
        //collision.gameObject.SetActive(false);

        if (!gameObject.tag.Contains(collision.gameObject.tag))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
