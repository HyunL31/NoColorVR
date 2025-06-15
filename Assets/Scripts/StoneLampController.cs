using UnityEngine;

public class StoneLampController : MonoBehaviour
{
    [SerializeField] private GameObject stoneLight;

    public LightPuzzle lightPuzzle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lamp"))
        {
            if (lightPuzzle != null)
            {
                if (!stoneLight.activeSelf && lightPuzzle.PuzzleType == "Rising")
                {
                    lightPuzzle.BuildingUp();
                    stoneLight.SetActive(true);
                }
                else if (lightPuzzle.PuzzleType == "Rising")
                {
                    lightPuzzle.BuildingDown();
                    stoneLight.SetActive(false);
                }

                if (!stoneLight.activeSelf && lightPuzzle.PuzzleType == "Spawning")
                {
                    stoneLight.SetActive(true);
                    lightPuzzle.SpawnObjects();
                }
            }
            else
            {
                stoneLight.SetActive(true);
            }
        }
    }
}
