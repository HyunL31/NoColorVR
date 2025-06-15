using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LampTrigger : XRBaseInteractable
{
    public ColorBallSpawner ballSpawner;

    // If grab the fire object, ColorBall will be spawned.
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (ballSpawner == null)
        {
            return;
        }

        if (ballSpawner.lamp.currentColor == ColorType.None)
        {
            return;
        }

        ballSpawner.interactor = args.interactorObject as XRBaseInteractor;
        ballSpawner.SpawnColorBall();
    }
}
