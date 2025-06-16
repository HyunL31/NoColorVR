using UnityEngine;

public class StoneLampController : MonoBehaviour
{
    [SerializeField] private GameObject stoneLight; // Visual light on the stone lamp

    public LightPuzzle lightPuzzle; // Reference to the puzzle controller
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = transform.parent.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Lamp"))
        {
            if (lightPuzzle != null)
            {
                // For Rising puzzle type, toggle platform and light
                if (!stoneLight.activeSelf && lightPuzzle.PuzzleType == "Rising")
                {
                    lightPuzzle.BuildingUp();
                    stoneLight.SetActive(true);
                    if (audioSource != null)
                        audioSource.Play();
                }
                else if (lightPuzzle.PuzzleType == "Rising")
                {
                    lightPuzzle.BuildingDown();
                    stoneLight.SetActive(false);
                    if (audioSource != null)
                        audioSource.Play();
                }

                // For Spawning puzzle type, toggle items and light
                if (!stoneLight.activeSelf && lightPuzzle.PuzzleType == "Spawning")
                {
                    stoneLight.SetActive(true);
                    lightPuzzle.SpawnObjects();
                    if (audioSource != null)
                        audioSource.Play();
                }
            }
            else // Default setting when lentern is activated. Just turn on light.
            {
                stoneLight.SetActive(true);
                if (audioSource != null)
                        audioSource.Play();
            }
        }
    }
}
