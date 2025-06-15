using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public List<GameObject> slotObjects;
    public List<Image> slotImages;
    public List<Image> HUDImages;

    public InputActionProperty showInventoryAction;

    public GameObject scrollUIPanel;
    public TextMeshProUGUI scrollText;

    public Transform rightHandTransform;

    void Update()
    {
        if (showInventoryAction.action.WasPressedThisFrame())
        {
            ToggleInventory();
        }
    }

    // Active Inventory UI
    public void ToggleInventory()
    {
        bool show = !inventoryPanel.activeSelf;
        inventoryPanel.SetActive(show);
        if (show)
        {
            UpdateInventoryUI();
        }
    }

    // Add Item in Inventory
    public void UpdateInventoryUI()
    {
        if (CharacterManager.Instance == null)
        {
            return;
        }

        var items = CharacterManager.Instance.characterData.GetItems();
        var keys = CharacterManager.Instance.characterData.GetKeys();

        for (int i = 0; i < slotObjects.Count; i++)
        {
            if (i < items.Count)
            {
                slotObjects[i].SetActive(true);
                slotImages[i].sprite = items[i].icon;
                slotImages[i].color = items[i].icon != null ? Color.white : Color.clear;
            }
            else
            {
                slotObjects[i].SetActive(false);
            }
        }

        for (int i = 0; i < HUDImages.Count; i++)
        {
            if (i < keys.Count)
            {
                HUDImages[i].sprite = keys[i].icon;
                HUDImages[i].color = keys[i].icon != null ? Color.white : Color.clear;
            }
            else
            {
                HUDImages[i].sprite = null;
            }
        }
    }

    // If touch item slot
    public void OnClickItem(int index)
    {
        var items = CharacterManager.Instance.characterData.GetItems();
        if (index >= items.Count)
        {
            return;
        }

        ItemData data = items[index];

        switch (data.itemType)
        {
            case ItemType.Key:
                SpawnItem(data);
                break;
            case ItemType.Scroll:
                scrollUIPanel.SetActive(true);
                scrollText.text = data.scrollContent;
                break;
        }

        //CharacterManager.Instance.characterData.RemoveItem(index);
        //UpdateInventoryUI();
    }

    private void SpawnItem(ItemData data)
    {
        if (data.itemPrefab == null) return;

        Camera mainCam = Camera.main;
        Vector3 spawnPos = mainCam.transform.position + mainCam.transform.forward * 0.5f;
        Quaternion spawnRot = Quaternion.LookRotation(mainCam.transform.forward);

        GameObject item = Instantiate(data.itemPrefab, spawnPos, spawnRot);

        ItemData newData = item.GetComponent<ItemData>();

        XRGrabInteractable grab = item.GetComponent<XRGrabInteractable>();
        Rigidbody rb = item.GetComponent<Rigidbody>();

        if (grab != null && rb != null)
        {
            grab.interactionManager = FindAnyObjectByType<XRInteractionManager>();
            rb.isKinematic = true;

            StartCoroutine(EnablePhysics(rb));
        }
    }

    private IEnumerator EnablePhysics(Rigidbody rb)
    {
        yield return new WaitForSeconds(0.2f);
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}
