using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LampTrigger : MonoBehaviour
{
    public ColorBallSpawner ballSpawner;
    public XRBaseInteractor fixedInteractor;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("currentColor = " + ballSpawner.lamp.currentColor);
        Debug.Log("Object name of Collider: " + other.name);

        if (ballSpawner == null || fixedInteractor == null)
        {
            Debug.Log("No Interactor");
            return;
        }

        if (ballSpawner.lamp.currentColor == ColorType.None)
        {
            Debug.Log("None Color");
            return;
        }

        ballSpawner.interactor = fixedInteractor;
        Debug.Log("Try to spawn color ball");
        ballSpawner.SpawnColorBall();
    }
}
