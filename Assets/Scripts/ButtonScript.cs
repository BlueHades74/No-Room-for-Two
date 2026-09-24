using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject door;

    private float maxDisplacement = 0.5f;
    private float currentDisplacement;
    private GameObject buttonBase;
    private bool pressed;

    public bool down { get; private set; }

    private void Start()
    {
        currentDisplacement = maxDisplacement;
        buttonBase = gameObject.transform.parent.gameObject;
    }

    private void FixedUpdate()
    {
        if (pressed)
        {
            currentDisplacement -= 2f * Time.deltaTime;
        }
        else
        {
            currentDisplacement += 2f * Time.deltaTime;
        }

        currentDisplacement = Mathf.Clamp(currentDisplacement, 0, maxDisplacement);

        down = (currentDisplacement == 0);

        Vector2 pos = buttonBase.transform.position;
        pos.y += (currentDisplacement + 0.1f)/5;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag.Contains(collision.gameObject.tag))
        {
            pressed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(gameObject.tag.Contains(collision.gameObject.tag))
        {
            pressed = false;
        }
    }
}
