﻿using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class LampTrigger : MonoBehaviour
{
    public ColorBallSpawner ballSpawner;
    public XRBaseInteractor fixedInteractor;

    private void OnTriggerEnter(Collider other)
    {
        if (ballSpawner == null || fixedInteractor == null)
        {
            return;
        }

        if (ballSpawner.lamp.currentColor == ColorType.None)
        {
            return;
        }

        ballSpawner.interactor = fixedInteractor;
        ballSpawner.SpawnColorBall();
    }
}