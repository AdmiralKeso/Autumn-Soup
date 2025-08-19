using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add this for TextMeshPro

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI inventoryText; // Changed from Text to TextMeshProUGUI

    // Must be public and void
    public void AddItemFromButton(Button button)
    {
        TextMeshProUGUI tmpText = button.GetComponentInChildren<TextMeshProUGUI>();
        if (tmpText == null)
        {
            Debug.LogWarning("Button has no TextMeshProUGUI component!");
            return;
        }

        string itemName = tmpText.text;
        Debug.Log("Adding item: " + itemName);

        InventoryManager.Instance.AddItem(itemName);
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (inventoryText == null)
        {
            Debug.LogWarning("Inventory TextMeshProUGUI component is missing!");
            return;
        }

        inventoryText.text = "Inventory:\n";
        foreach (string item in InventoryManager.Instance.items)
        {
            inventoryText.text += item + "\n";
        }
    }
}