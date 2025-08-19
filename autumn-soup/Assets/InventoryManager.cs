using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<string> items = new List<string>();

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
        items.Add(itemName);
        Debug.Log("Added: " + itemName);
    }

    // Removes an item (optional)
    public void RemoveItem(string itemName)
    {
        items.Remove(itemName);
        Debug.Log("Removed: " + itemName);
    }
}
