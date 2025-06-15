using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Color Control with UI
/// </summary>

public enum ColorType
{
    None,
    Red,
    Blue,
    Green,
    Yellow
}

public class ColorController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject menuUI;        // Button UI Panel
    public LampController lamp;      // Lamp Controller
    private bool isMenuOpen = false;
    public InputActionReference submitAction;

    void Update()
    {
        if (submitAction.action.triggered && gameManager.gamePhase==GameManager.GamePhase.Level2)
        {
            isMenuOpen = !isMenuOpen;
            menuUI.SetActive(isMenuOpen);
        }
    }

    // If press the primary button, the color selector UI will be active.
    public void SelectColor(int colorIndex)
    {
        ColorType selectedColor = (ColorType)colorIndex;
        lamp.SetColor(selectedColor);

        menuUI.SetActive(false);
    }
}
