using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// If press the secondary button, the menu panel will be active.
/// </summary>

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public InputActionProperty pauseAction;     // Secondary Button

    private bool isPaused = false;

    void Update()
    {
        if (pauseAction.action.WasPressedThisFrame())
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Pause with Menu Panel
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    // Play again
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
}
