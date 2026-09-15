using Unity.Cinemachine;
using UnityEngine;

public class PlayerVertDistCheck : MonoBehaviour
{
    [SerializeField] private CinemachineBrain brain1;
    [SerializeField] private CinemachineBrain brain2;
    [SerializeField] private CinemachineCamera monoCam1;
    [SerializeField] private CinemachineCamera monoCam2;
    [SerializeField] private Transform Player1;
    [SerializeField] private Transform Player2;
    [SerializeField] private float breakDistance = 6;

    private void LateUpdate()
    {
        if (brain1.IsBlending || brain2.IsBlending) return;

        if (Player1.position.y + 2 > Player2.position.y)
        {
            monoCam1.Target.TrackingTarget = Player1;
            monoCam2.Target.TrackingTarget = Player2;
        }
        else
        {
            monoCam1.Target.TrackingTarget = Player2;
            monoCam2.Target.TrackingTarget = Player1;
        }

        if (Mathf.Abs(Player2.position.y - Player1.position.y) > breakDistance)
        {
            monoCam1.Priority = 20;
            monoCam2.Priority = 20;
        }
        else
        {
            monoCam1.Priority = 0;
            monoCam2.Priority = 0;
        }
    }
}
