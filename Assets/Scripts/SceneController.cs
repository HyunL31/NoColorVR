using UnityEngine;

/// <summary>
/// Control Scene Script
/// </summary>

public class SceneController : MonoBehaviour
{
    public GameObject titlePanel;
    public GameObject menuPanel;
    public GameObject clueUI;

    public void StartButton()
    {
        titlePanel.SetActive(false);
    }

    public void HomeButton()
    {
        menuPanel.SetActive(false);
        titlePanel.SetActive(true);
    }
    public void MenuButton()
    {
        menuPanel.SetActive(true);
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
}
