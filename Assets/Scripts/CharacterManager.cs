using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterData characterData;
    [SerializeField] GameObject Character;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterData = new CharacterData();
        characterData.Health = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class CharacterData
{
    private int health;
    public int Health
    {
        get { return health; }
        set { if (value >= 0) health = value; }
    }
    private List<GameObject> items = new List<GameObject>();
    public void AddItem(GameObject go)
    {
        if (go != null)
            items.Add(go);
    }
    public List<GameObject> GetItems()
    {
        List<GameObject> returnItems = new List<GameObject>();
        foreach (GameObject go in items)
            returnItems.Add(go);
        return returnItems;
    }

    public void DeleteItems(int i)
    {
        if (i == -1)
            items.Clear();
        else if (i >= 0 && items.Count > i)
            items.RemoveAt(i);
    }
}
