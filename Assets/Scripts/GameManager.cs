using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    private int uiIndex = 0;

    private void OnEnable()
    {
        HazardDamage.playerDied += GameOver;
    }

    private void OnDisable()
    {
        HazardDamage.playerDied -= GameOver;
    }

    private void GameOver(GameObject player)
    {
        Debug.Log(player.name + " has died");

        uiIndex++;

        var txt = gameOverUI.transform.GetChild(uiIndex).GetComponent<TextMeshProUGUI>();
        txt.text = (player.name + " has died");

        StartCoroutine(GameOverAndRestart());
    }

    IEnumerator GameOverAndRestart()
    {
        yield return new WaitForSeconds(1);

        gameOverUI.SetActive(true);
        
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
