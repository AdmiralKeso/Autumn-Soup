using System.Collections;
using UnityEngine;

public class GrillInteraction : MonoBehaviour
{
    private bool playerInRange = false;
    private bool isCooking = false;

    // Recipe for Steak Frites
    private Recipe SteakFrites = new Recipe
    {
        dishName = "Steak Frites",
        requiredIngredients = new System.Collections.Generic.List<string>
        {
            "Beef",
            "Fries",
            "Bearnaise"
        }
    };

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TryCook(SteakFrites);
        }
    }

    private void TryCook(Recipe recipe)
    {
        if (isCooking)
            return;

        var inventory = InventoryManager.Instance.items;

        // Check if all required ingredients exist
        foreach (string ingredient in recipe.requiredIngredients)
        {
            if (!inventory.Contains(ingredient))
            {
                Debug.LogWarning("Missing ingredient: " + ingredient);
                return;
            }
        }

        // Remove ingredients immediately
        foreach (string ingredient in recipe.requiredIngredients)
        {
            InventoryManager.Instance.RemoveItem(ingredient);
            Debug.Log("Used ingredient: " + ingredient);
        }

        // Start cooking coroutine
        StartCoroutine(CookAfterDelay(recipe));
    }

    private IEnumerator CookAfterDelay(Recipe recipe)
    {
         isCooking = true;
    Debug.Log("Cooking " + recipe.dishName + "...");

    // Remove ingredients
    foreach (string ingredient in recipe.requiredIngredients)
    {
        InventoryManager.Instance.RemoveItem(ingredient);
        Debug.Log("Used ingredient: " + ingredient);
    }

    FindObjectOfType<InventoryUI>().UpdateUI();

    yield return new WaitForSeconds(10f); // wait 10 seconds

    // Add the cooked dish
    InventoryManager.Instance.AddItem(recipe.dishName);
    Debug.Log("Cooked: " + recipe.dishName);

    FindObjectOfType<InventoryUI>().UpdateUI();

    isCooking = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
