using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<string> items = new List<string>();
    public int maxItems = 6; // Maximum items allowed

    // List of proteins
    private List<string> proteinItems = new List<string>() { "Beef", "Pork", "Duck" };

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

        // Check if the item is a protein and if a protein already exists
        if (proteinItems.Contains(itemName))
        {
            foreach (string item in items)
            {
                if (proteinItems.Contains(item))
                {
                    Debug.LogWarning("You can only have one protein in the inventory!");
                    return;
                }
            }
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

    internal void RemoveItem(string ingredient, string v)
    {
        throw new NotImplementedException();
    }

    internal void AddItem(string dishName, string v)
    {
        throw new NotImplementedException();
    }
}

