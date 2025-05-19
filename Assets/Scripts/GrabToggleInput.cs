using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabToggleInput : MonoBehaviour
{
    public XRDirectInteractor directInteractor;
    public XRNode handNode = XRNode.RightHand;

    private bool lastGripPressed = false;

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(handNode);
        if (device.TryGetFeatureValue(CommonUsages.gripButton, out bool gripPressed))
        {
            if (gripPressed && !lastGripPressed)
            {
                // 최신 방식으로 현재 잡고 있는 Interactable 가져오기
                IXRSelectInteractable selected = directInteractor.GetOldestInteractableSelected();

                if (selected != null)
                {
                    var component = (selected as Component)?.GetComponent<ToggleGrabInteractable>();
                    component?.ToggleRelease();
                }
            }
            lastGripPressed = gripPressed;
        }
    }
}
