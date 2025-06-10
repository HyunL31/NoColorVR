using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ItemPickup : XRBaseInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        CharacterManager.characterData.AddItem(gameObject);
        Debug.Log("Pick up Item: " + gameObject.name);

        FindAnyObjectByType<InventoryUI>()?.UpdateInventoryUI();

        gameObject.SetActive(false);
    }
}
