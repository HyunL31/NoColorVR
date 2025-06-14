using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/// <summary>
/// Color Ball Spawn Script
/// </summary>

public class ColorBallSpawner : MonoBehaviour
{
    // Color Ball Prefab
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

        if (prefabToSpawn == null || interactor == null)
        {
            return;
        }

        // Color ball spawn
        GameObject ball = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        XRGrabInteractable grabInteractable = ball.GetComponent<XRGrabInteractable>();

        // Prevent to slip or fall color ball
        if (grabInteractable != null)
        {
            StartCoroutine(DelayedAttach(ball, grabInteractable));
        }
    }

    // For Grabbing Color Ball
    public IEnumerator DelayedAttach(GameObject ball, XRGrabInteractable interactable)
    {
        yield return new WaitForEndOfFrame();

        if (interactor != null && interactable != null)
        {
            interactor.interactionManager.SelectEnter(
                (IXRSelectInteractor)interactor,
                (IXRSelectInteractable)interactable
            );
        }
    }

    // Changing Ball Color with Lamp Color
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
