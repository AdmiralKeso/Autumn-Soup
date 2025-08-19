using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<string> items = new List<string>();
    public int maxItems = 6; // Maximum items allowed

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Adds a new item to the inventory
    public void AddItem(string itemName)
    {
        if (items.Count >= maxItems)
        {
            Debug.LogWarning("Inventory full! Cannot add: " + itemName);
            return;
        }

        items.Add(itemName);
        Debug.Log("Added: " + itemName);
    }

    // Removes an item (optional)
    public void RemoveItem(string itemName)
    {
        if (items.Contains(itemName))
        {
            items.Remove(itemName);
            Debug.Log("Removed: " + itemName);
        }
    }
}
