using UnityEngine;

public class StoneLampController : MonoBehaviour
{
    [SerializeField] private GameObject stoneLight;

    public LightPuzzle lightPuzzle;
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

                if (!stoneLight.activeSelf && lightPuzzle.PuzzleType == "Spawning")
                {
                    stoneLight.SetActive(true);
                    lightPuzzle.SpawnObjects();
                    if (audioSource != null)
                        audioSource.Play();
                }
            }
            else
            {
                stoneLight.SetActive(true);
                if (audioSource != null)
                        audioSource.Play();
            }
        }
    }
}
