using UnityEngine;

// Item Type
public enum ItemType
{
    Key,
    Scroll
}

public class ItemData : MonoBehaviour
{
    public Sprite icon;
    public string itemName;
    public ItemType itemType;
    public GameObject itemPrefab;

    [TextArea]
    public string scrollContent;

    // Convert to ItemInfo
    public ItemInfo ToItemInfo()
    {
        return new ItemInfo
        {
            itemName = this.itemName,
            icon = this.icon,
            itemType = this.itemType,
            scrollContent = this.scrollContent,
            itemPrefab = this.itemPrefab
        };
    }
}