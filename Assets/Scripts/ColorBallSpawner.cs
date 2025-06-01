using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

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
            Debug.LogWarning("No Prefab with currentColor");
            return;
        }

        GameObject ball = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        Debug.Log($"Color ball: {ball.name}");

        if (ball.TryGetComponent(out IXRSelectInteractable grabInteractable))
        {
            interactor.StartManualInteraction(grabInteractable);
        }
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
