using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightPuzzle : MonoBehaviour
{
    [SerializeField] private GameObject building;
    [SerializeField] private List<GameObject> spawns;

    public float buildingMax = 3; // Maximum Y height of the platform
    public float buildingMin = -10; // Minimum Y height of the platform
    private bool buildingFlag = false; // Flag to prevent multiple movements at once
    public GameObject player; // Reference to the player object
    public string PuzzleType = "Rising"; // Type of puzzle

    // Start coroutine then specific ground is rising.
    public void BuildingUp()
    {
        if (buildingFlag == false)
            StartCoroutine(Uprise());
    }

    // Start coroutine then specific ground is sinking.
    public void BuildingDown()
    {
        if (buildingFlag == false)
            StartCoroutine(Down());
    }

    // Trigger haptic feedback and move platform upward.
    private IEnumerator Uprise()
    {
        CharacterManager.Instance.ManualHapticFeedBack(0.5f, 6f);
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null) audioSource.Play();
        buildingFlag = true;
        while (building.transform.localPosition.y < buildingMax)
        {
            building.transform.Translate(Vector3.up * 0.01f);
            player.transform.Translate(Vector3.up * 0.01f);
            yield return null;
        }
        buildingFlag = false;
        yield break;
    }

    // Trigger haptic feedback and move platform downward.
    private IEnumerator Down()
    {
        CharacterManager.Instance.ManualHapticFeedBack(0.5f, 6f);
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null) audioSource.Play();
        buildingFlag = true;
        while (building.transform.localPosition.y > buildingMin)
        {
            building.transform.Translate(Vector3.down * 0.01f);
            player.GetComponent<CharacterController>().Move(Vector3.zero);
            yield return null;
        }
        buildingFlag = false;
        yield break;
    }

    // If puzzle type is spawning, this method is executed.
    public void SpawnObjects()
    {
        foreach (GameObject gameObject in spawns)
        {
            gameObject.SetActive(true);
        }
    }
}
