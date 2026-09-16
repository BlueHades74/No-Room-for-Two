using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class StartGame : MonoBehaviour
{
    [SerializeField] private string scene;
    private Controls input;

    private void Awake()
    {
        input = new Controls();
    }

    private void OnEnable()
    {
        input.Player1.Enable();
        input.Player2.Enable();
        input.Player1.Move.performed += hopToNextScene;
        input.Player1.Jump.performed += hopToNextScene;
        input.Player2.Move.performed += hopToNextScene;
        input.Player2.Jump.performed += hopToNextScene;
    }

    private void OnDisable()
    {
        input.Player1.Disable();
        input.Player2.Disable();
        input.Player1.Move.performed -= hopToNextScene;
        input.Player1.Jump.performed -= hopToNextScene;
        input.Player2.Move.performed -= hopToNextScene;
        input.Player2.Jump.performed -= hopToNextScene;
    }

    private void hopToNextScene(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene(scene);
    }
}
