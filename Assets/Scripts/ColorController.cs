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
    public GameObject menuUI;        // Button UI Panel
    public LampController lamp;      // Lamp Controller
    private bool wasPressed = false;
    private bool isMenuOpen = false;
    public InputActionReference submitAction;

    private bool isMenuActive = false;

    void Update()
    {
        if (submitAction.action.triggered)
        {
            isMenuOpen = !isMenuOpen;
            menuUI.SetActive(isMenuOpen);
        }
    }

    // UI 버튼에서 호출할 함수
    public void SelectColor(int colorIndex)
    {
        ColorType selectedColor = (ColorType)colorIndex;
        lamp.SetColor(selectedColor);

        isMenuActive = false;
        menuUI.SetActive(false);
    }
}
