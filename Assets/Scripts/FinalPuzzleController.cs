using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FinalPuzzleController : MonoBehaviour
{
    [SerializeField] private List<GameObject> Gems; // Gems to activate
    [SerializeField] private GameObject slope; // Final platform to raise
    [SerializeField] private InventoryUI inventoryUI; // UI reference to update inventory

    /// <summary>
    /// When lamp is attached to alter (table at the Largest hall), this script is executed.
    /// </summary>
    public void LampAttach()
    {
        // Check if player has all 4 keys
        if (CharacterManager.Instance.characterData.GetKeys().Count == 4)
        {
            CharacterManager.Instance.characterData.ClearAllKeys(); // Clear keys from inventory
            foreach (GameObject gameObject in Gems)
            {
                gameObject.SetActive(true);
                inventoryUI.UpdateInventoryUI();
                StartCoroutine(Uprise());
            }
        }
    }
    
    private IEnumerator Uprise() //Raise platform
    {
        CharacterManager.Instance.ManualHapticFeedBack(0.5f, 4f);
        AudioSource audioSource = GetComponent<AudioSource>();
        if(audioSource!=null) audioSource.Play();
        while (slope.transform.localPosition.y < 0)
        {
            slope.transform.Translate(Vector3.up * 0.01f);
            yield return null;
        }
        yield break;
    }
}
