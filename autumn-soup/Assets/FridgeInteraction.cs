using UnityEngine;

public class FridgeInteraction : MonoBehaviour
{
    public GameObject FridgeUI;
    private bool playerInRange = false;

    void Start()
    {
        FridgeUI.SetActive(false);
    }
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            bool isActive = FridgeUI.activeSelf;
            FridgeUI.SetActive(!isActive);
            Debug.Log("Player entered trigger");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            FridgeUI.SetActive(false);
        }
    }
}