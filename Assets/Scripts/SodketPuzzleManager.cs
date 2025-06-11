using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class SodketPuzzleManager : MonoBehaviour
{
    [SerializeField] XRSocketInteractor[] sockets; //sockets for clear final puzzle
    private bool puzzleSolved = false;

    void Update()
    {
        if (puzzleSolved) return; //if puzzle is already cleared, update isn't needed

        bool allFilled = true;

        foreach (var socket in sockets)
        {
            if (!socket.hasSelection)
            {
                allFilled = false;
                break;
            }
        }

        if (allFilled)
        {
            FinalPuzzleClear();
            puzzleSolved = true;
        }
    }

    /// <summary>
    /// Method for making the route to lavel2.
    /// If player collect and attach to socket all items for clear puzzle, this method is executed
    /// </summary>
    private void FinalPuzzleClear()
    {
        Debug.Log("all puzzle is cleared");
    }
}
