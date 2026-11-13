using UnityEngine;

public class FridgeInteract : MonoBehaviour
{
    public GameObject fridgeInventory;

    private bool playerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Гравець біля холодильника");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Гравець відійшов від холодильника");
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            fridgeInventory.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log("Холодильник відкрито");
        }
    }
}