using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private ButtonScript button;
    [SerializeField] private float maxClimb;
    [SerializeField] private float climbSpeed;
    [SerializeField] private bool test;

    private Vector2 origPos;

    private void OnValidate()
    {
        MatchButtonColor();
    }

    private void Start()
    {
        MatchButtonColor();
        origPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (button != null)
        {
            Vector2 pos = transform.position;

            if (test)
            {
                pos.y += climbSpeed * Time.deltaTime;
            }
            else
            {
                pos.y -= climbSpeed * Time.deltaTime;
            }

            pos.y = Mathf.Clamp(pos.y, origPos.y, origPos.y + maxClimb);

            transform.position = pos;
        }
    }

    private void MatchButtonColor()
    {
        GameObject colorLight = gameObject.transform.GetChild(0).gameObject;

        if (button != null)
        {
            colorLight.GetComponent<SpriteRenderer>().color = button.gameObject.GetComponent<SpriteRenderer>().color;
        }
        else
        {
            colorLight.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
