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
        gameObject.transform.position = new Vector2((BluePlayer.position.x + RedPlayer.position.x) / 2, gameObject.transform.position.y);
    }
}
