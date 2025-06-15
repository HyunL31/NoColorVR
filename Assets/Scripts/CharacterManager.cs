using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }
    public CharacterData characterData { get; private set; }
    [SerializeField] private SceneController sceneController;
    [SerializeField] private BloodEffectUI bloodEffectUI;

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

    public void ApplyDamage(int damage)
    {
        Instance.characterData.Health -= damage;
        bloodEffectUI.CalculateDamage();
        if (Instance.characterData.CheckDie())
        {
            sceneController.GameOver();
        }
    }
}

public class CharacterData
{
    private int health = 30;
    public int Health
    {
        get => health;
        set { if (value >= 0) health = value; }
    }

    private List<ItemData> items = new List<ItemData>();
    private List<ItemData> keys = new List<ItemData>();

    public void AddItem(ItemData itemData)
    {
        if (itemData != null && itemData.itemType == ItemType.Scroll)
        {
            items.Add(itemData);
        }
        else if (itemData != null && itemData.itemType == ItemType.Key)
        {
            keys.Add(itemData);
        }
    }

    public List<ItemData> GetItems() => new List<ItemData>(items);
    public List<ItemData> GetKeys() => new List<ItemData>(keys);

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

    public void ClearAllKeys()
    {
        keys.Clear();
    }

    public bool CheckDie()
    {
        if (health > 0)
        {
            return false;
        }
        else return true;
    }
}
