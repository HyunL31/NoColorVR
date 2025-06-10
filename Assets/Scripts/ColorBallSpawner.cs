using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/// <summary>
/// Color Ball Interaction
/// </summary>

public class ColorBallSpawner : MonoBehaviour
{
    public GameObject redPrefab;
    public GameObject bluePrefab;
    public GameObject greenPrefab;
    public GameObject yellowPrefab;

    public Transform spawnPoint;
    public LampController lamp;
    [HideInInspector] public XRBaseInteractor interactor;

    public void SpawnColorBall()
    {
        GameObject prefabToSpawn = GetPrefabByColor(lamp.currentColor);
        if (prefabToSpawn == null)
        {
            return;
        }

        GameObject ball = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
    }

    private GameObject GetPrefabByColor(ColorType color)
    {
        return color switch
        {
            ColorType.Red => redPrefab,
            ColorType.Blue => bluePrefab,
            ColorType.Green => greenPrefab,
            ColorType.Yellow => yellowPrefab,
            _ => null
        };
    }
}