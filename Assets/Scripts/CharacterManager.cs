using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; } // Singleton instance
    public CharacterData characterData { get; private set; } // Player data
    [SerializeField] private SceneController sceneController; // Reference to scene handler
    [SerializeField] private BloodEffectUI bloodEffectUI; // UI for damage feedback
    [SerializeField] private HapticImpulsePlayer left; // Left-hand haptic feedback
    [SerializeField] private HapticImpulsePlayer right; // Right-hand haptic feedback


    void Awake()
    {
        // Singleton setup
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

    /// <summary>
    /// If player collide with enemy, this is executed from Monster.
    /// </summary>
    /// <param name="damage"></param>
    public void ApplyDamage(int damage)
    {
        Instance.characterData.Health -= damage; // Apply damage to health
        ManualHapticFeedBack(1f, 1f); // Trigger haptic feedback
        bloodEffectUI.CalculateDamage(); // Show blood effect
        if (Instance.characterData.CheckDie())
        {
            sceneController.GameOver(); // Trigger game over
        }
    }

    public void ManualHapticFeedBack(float amplitude, float duration)
    {
        left.SendHapticImpulse(amplitude, duration); // Haptic on left hand
        right.SendHapticImpulse(amplitude, duration); // Haptic on right hand
    }
}

/// <summary>
/// CharacterData have player's health, items and can control them.
/// </summary>
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

    // Add scroll or key based on item type
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
            items.RemoveAt(index); // Remove scroll by index
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

    // Returns true if dead
    public bool CheckDie()
    {
        if (health > 0)
        {
            return false;
        }
        else return true;
    }
}
