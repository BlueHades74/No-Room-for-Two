using UnityEngine;

public class SidescrollerScript : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;

    private float displacement;
    private Vector2 tempPos;

    private void Awake()
    {
        if (player1 == null)
        {
            Debug.LogError("Player 1 is unassigned!");
        }

        if (player2 == null)
        {
            Debug.LogError("Player 2 is unassigned!");
        }

        //Determine how far from the screen the players should be kept
        Camera cam = transform.GetChild(0).GetComponent<Camera>();
        displacement = (cam.orthographicSize*cam.aspect) - (player1.GetComponent<SpriteRenderer>().bounds.size.x/2);
    }

    private void FixedUpdate()
    {
        MoveCenter();
        BoundPlayer(player1);
        BoundPlayer(player2);
    }

    private void MoveCenter()
    {
        //This moves the screen, or more accurately the Camera's parent which is what this script should be attached to
        Vector2 pos = transform.position;
        pos.x += scrollSpeed * Time.deltaTime;
        transform.position = pos;
    }

    private void BoundPlayer(GameObject player)
    {
        //This keeps the player inside the camera
        tempPos = player.transform.position;
        tempPos.x = Mathf.Clamp(tempPos.x, transform.position.x - displacement, transform.position.x + displacement);
        player.transform.position = tempPos;
    }
}
