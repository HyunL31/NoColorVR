using UnityEngine;

/// <summary>
/// Control Scene Script
/// </summary>

public class SceneController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject titlePanel;
    public GameObject menuPanel;
    public GameObject clueUI;
    public GameObject gameOverUI;
    public GameObject endingUI;

    private GameManager.GamePhase currentGamePhase;

    public void StartButton()
    {
        titlePanel.SetActive(false);
        gameManager.ChangeGamePhase(2);
    }

    public void HomeButton()
    {
        menuPanel.SetActive(false);
        titlePanel.SetActive(true);
        gameManager.ChangeGamePhase(1);
    }
    public void MenuButton()
    {
        currentGamePhase = gameManager.gamePhase;
        menuPanel.SetActive(true);
        gameManager.ChangeGamePhase(3);
    }

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void CloseButton()
    {
        clueUI.SetActive(false);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        gameManager.ChangeGamePhase(3);
        Time.timeScale = 0f;
    }

    public void ReStart()
    {
        gameOverUI.SetActive(false);
        gameManager.ResetLevel();
        gameManager.ChangeGamePhase(4);
    }

    public void EndTitle()
    {
        endingUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
