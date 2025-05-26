using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics.HapticsUtility;

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
    public GameObject menuUI;        // 버튼 UI 패널
    public LampController lamp;      // 램프 컨트롤러 참조
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
