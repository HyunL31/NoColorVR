using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FinalPuzzleController : MonoBehaviour
{
    [SerializeField] private List<GameObject> Gems;
    [SerializeField] private GameObject slope;
    [SerializeField] private InventoryUI inventoryUI;

    public void LampAttach()
    {
        if (CharacterManager.Instance.characterData.GetKeys().Count == 4)
        {
            CharacterManager.Instance.characterData.ClearAllKeys();
            foreach (GameObject gameObject in Gems)
            {
                gameObject.SetActive(true);
                inventoryUI.UpdateInventoryUI();
                StartCoroutine(Uprise());
            }
        }
    }
    
    private IEnumerator Uprise()
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
