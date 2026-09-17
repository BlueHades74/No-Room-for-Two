using UnityEngine;

public class MovingWallMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;

    private void FixedUpdate()
    {
        MoveWall();
    }

    private void MoveWall()
    {
        transform.Translate(new Vector3(movementSpeed, 0, 0));
    }
}
