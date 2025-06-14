using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }
    public CharacterData characterData { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            characterData = new CharacterData();
            characterData.Health = 30;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

public class CharacterData
{
    private int health;
    public int Health
    {
        get => health;
        set { if (value >= 0) health = value; }
    }

    private List<ItemData> items = new List<ItemData>();

    public void AddItem(ItemData itemData)
    {
        if (itemData != null)
        {
            items.Add(itemData);
        }
    }

    public List<ItemData> GetItems() => new List<ItemData>(items);

    public void RemoveItem(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items.RemoveAt(index);
        }
    }

    public void ClearAllItems()
    {
        items.Clear();
    }
}
