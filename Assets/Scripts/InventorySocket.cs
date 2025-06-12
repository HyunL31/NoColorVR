using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

/// <summary>
/// Add item to inventory
/// </summary>

public class InventorySocket : MonoBehaviour
{
    private XRSocketInteractor socket;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.selectEntered.AddListener(OnItemInserted);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnItemInserted);
    }

    private void OnItemInserted(SelectEnterEventArgs args)
    {
        GameObject item = args.interactableObject.transform.gameObject;

        ItemData data = item.GetComponent<ItemData>();
        if (data != null && CharacterManager.Instance != null)
        {
            CharacterManager.Instance.characterData.AddItem(data);

            FindAnyObjectByType<InventoryUI>()?.UpdateInventoryUI();

            Destroy(item);
        }
    }
}