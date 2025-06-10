using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    [Header("UI Connecting")]
    public GameObject inventoryPanel;
    public List<GameObject> slotObjects;
    public List<Image> slotImages;

    [Header("Input Setting")]
    public InputActionProperty showInventoryAction;

    void Update()
    {
        if (showInventoryAction.action.WasPressedThisFrame())
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        bool show = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(show);
        if (show) UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        var items = CharacterManager.characterData?.GetItems();
        if (items == null) return;

        for (int i = 0; i < slotObjects.Count; i++)
        {
            if (i < items.Count)
            {
                slotObjects[i].SetActive(true);
                SpriteRenderer sr = items[i].GetComponent<SpriteRenderer>();
                slotImages[i].sprite = sr != null ? sr.sprite : null;
                slotImages[i].color = Color.white;
            }
            else
            {
                slotObjects[i].SetActive(false);
            }
        }
    }

    public void OnClickItem(int index)
    {
        var items = CharacterManager.characterData?.GetItems();
        if (items == null || index >= items.Count) return;

        GameObject usedItem = items[index];
        Debug.Log("Used Item: " + usedItem.name);

        CharacterManager.characterData.DeleteItems(index);
        UpdateInventoryUI();
    }
}