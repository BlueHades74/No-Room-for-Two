using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorSceneSwap : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private int secondsToWaitInExit = 6;
    private int playersInExits = 0;
    private int ticksInExit = 0;

    public static event System.Action<bool> bothPlayersInExits;

    private void OnEnable()
    {
        ExitDoorPlayerCheck.playerEntered += AddTotalPlayers;
        ExitDoorPlayerCheck.playerExited += SubTotalPlayers;
    }

    private void OnDisable()
    {
        ExitDoorPlayerCheck.playerEntered -= AddTotalPlayers;
        ExitDoorPlayerCheck.playerExited -= SubTotalPlayers;
    }

    private void AddTotalPlayers()
    {
        playersInExits++;
        if (playersInExits == 2)
        {
            StartCoroutine(TimeInExit());
            bothPlayersInExits?.Invoke(true);
        }
    }
    
    private void SubTotalPlayers()
    {
        playersInExits--;
        StopAllCoroutines();
        bothPlayersInExits?.Invoke(false);
        ticksInExit = 0;
    }

    private void LoadNewScene()
    {
        // add code to transfer to next scene
        Debug.Log($"Loading {sceneToLoad}...");
        if (sceneToLoad != null) SceneManager.LoadScene(sceneToLoad);
        else Debug.LogError("Nothing found in sceneToLoad variable!");
    }

    private IEnumerator TimeInExit()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            Debug.Log($"ticksInExit: {ticksInExit}");

            ticksInExit++;

            if (ticksInExit == secondsToWaitInExit) LoadNewScene();
        }
    }
}
