using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Climbing;

public class FixedGravity : MonoBehaviour
{
    private CharacterController characterController;
    private ClimbProvider climbProvider;

    [SerializeField]
    private bool forceGravityCheck = true;

    void Awake()
    {
        characterController = FindAnyObjectByType<CharacterController>();
        climbProvider = FindAnyObjectByType<ClimbProvider>();
    }

    void OnEnable()
    {
        climbProvider.locomotionStarted += LocomotionStarted;
        climbProvider.locomotionEnded += LocomotionEnded;
    }

    // Update is called once per frame
    void Update()
    {
        if (forceGravityCheck)
        {
            characterController.SimpleMove(Vector3.zero); 
        }
    }

    void OnDisable()
    {
        climbProvider.locomotionStarted -= LocomotionStarted;
        climbProvider.locomotionEnded -= LocomotionEnded;
    }

    private void LocomotionStarted(LocomotionProvider provider)
    {
        forceGravityCheck = false;
    }

    private void LocomotionEnded(LocomotionProvider provider)
    {
        forceGravityCheck = true;
    }
}
