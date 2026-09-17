using UnityEngine;

public class PlayerMidpointCalc : MonoBehaviour
{
    // this script is for test purposes only
    // to be used when side scroller is disabled
    [SerializeField] private Transform BluePlayer;
    [SerializeField] private Transform RedPlayer;

    private void LateUpdate()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        // Grab the midpoint between the players and set the position to that value
        transform.position = new Vector2((BluePlayer.position.x + RedPlayer.position.x) / 2,
                                                    (BluePlayer.position.y + RedPlayer.position.y) / 2);
    }
}
