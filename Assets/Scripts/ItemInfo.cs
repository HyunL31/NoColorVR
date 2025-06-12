using UnityEngine;

/// <summary>
/// Saving Item Information
/// </summary>

[System.Serializable]
public class ItemInfo
{
    public string itemName;
    public Sprite icon;
    public ItemType itemType;
    public string scrollContent;
    public GameObject itemPrefab;
}