using UnityEngine;

public class MenuTrigger2D : MonoBehaviour
{
    public GameObject menuUI;       // Assign your menu PNG here
    private bool playerInRange = false;

    void Start()
    {
        menuUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            menuUI.SetActive(false);   // Hide menu when player leaves
            Debug.Log("Player left trigger");
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            menuUI.SetActive(!menuUI.activeSelf); // Toggle menu
        }
    }
}
