using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [Header("Item Configuration")]
    public string itemName;
    public Sprite itemIcon;

    private bool playerInside = false;
    private InventoryManager manager;

void Update()
{
    if (UnityEngine.InputSystem.Keyboard.current != null && 
        UnityEngine.InputSystem.Keyboard.current.eKey.wasPressedThisFrame)
    {
        
        if (playerInside && manager != null)
        {
            bool pickedUp = manager.AddItem(itemName, itemIcon);
            if (pickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}


    void AttemptPickup()
    {
        if (manager != null)
        {
            bool pickedUp = manager.AddItem(itemName, itemIcon);
            if (pickedUp)
            {
                Destroy(gameObject);
            }
            else
            {
            }
        }
        else
        {
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            manager = other.GetComponent<InventoryManager>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            manager = null;
        }
    }
}
