using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ToggleGrabInteractable : XRGrabInteractable
{
    private bool isToggledGrabbed = false;
    private XRBaseInteractor currentInteractor;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        currentInteractor = args.interactorObject as XRBaseInteractor;
        isToggledGrabbed = true;

        interactionManager.SelectEnter(
        currentInteractor as IXRSelectInteractor,
        this as IXRSelectInteractable
        );
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (!isToggledGrabbed)
        {
            base.OnSelectExited(args);
            currentInteractor = null;
        }
    }

    public void ToggleRelease()
    {
        Debug.Log("ToggleRelease() »£√‚µ !");

        if (isToggledGrabbed && currentInteractor != null)
        {
            interactionManager.SelectExit(
                currentInteractor as IXRSelectInteractor,
                this as IXRSelectInteractable
            );
            Debug.Log("Released!");
            isToggledGrabbed = false;
            currentInteractor = null;
        }
    }

}
