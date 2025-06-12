using UnityEngine;

/// <summary>
/// Lamp Color Control
/// </summary>

public class LampController : MonoBehaviour
{
    public ColorType currentColor = ColorType.None;
    public Light lampLight;

    public void SetColor(ColorType newColor)
    {
        currentColor = newColor;
        lampLight.color = GetUnityColor(newColor);
    }

    private Color GetUnityColor(ColorType type)
    {
        return type switch
        {
            ColorType.Red => Color.red,
            ColorType.Blue => Color.blue,
            ColorType.Green => Color.green,
            ColorType.Yellow => Color.yellow,
            _ => Color.white
        };
    }
}