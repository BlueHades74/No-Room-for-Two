using UnityEngine;

public class PlayerYTracker : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform scrollerCam;

    private void FixedUpdate()
    {
        gameObject.transform.position = new Vector2(scrollerCam.position.x, player.position.y);
    }
}
