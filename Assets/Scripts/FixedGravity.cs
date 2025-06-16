using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Climbing;


/// <summary>
/// Script for fix gravity when player is climbing.
/// For respawning and controlling the puzzle, it works only 5 seconds.
/// </summary>
public class FixedGravity : MonoBehaviour
{
    private CharacterController characterController; // characterController to move
    private ClimbProvider climbProvider; // for checking the plyer is climbing

    [SerializeField]
    private bool forceGravityCheck = false;

    void Awake()
    {
        characterController = FindAnyObjectByType<CharacterController>();
        climbProvider = FindAnyObjectByType<ClimbProvider>();
        forceGravityCheck = false;
    }

    void OnEnable()
    {
        climbProvider.locomotionStarted += LocomotionStarted;
        climbProvider.locomotionEnded += LocomotionEnded;
    }

    
    void Update()
    {
        if (forceGravityCheck) // if player stop the climbing, this condition enable and give gravity to player
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

    /// <summary>
    /// When player stop the climbing, coroutine is started.
    /// </summary>
    /// <param name="provider"></param>
    private void LocomotionEnded(LocomotionProvider provider)
    {
        forceGravityCheck = true;
        StartCoroutine(GiveGravity());
    }

    /// <summary>
    /// After 5seconds from start of coroutine, condition is changed and fix gravity doesn't work by changing
    /// forceGravityCheck condition.
    /// </summary>
    /// <returns></returns>
    private IEnumerator GiveGravity()
    {
        int a = 0;
        while (a < 5 && forceGravityCheck == true)
        {
            a++;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("gravity!");
        forceGravityCheck = false;
        yield break;
    }
}
