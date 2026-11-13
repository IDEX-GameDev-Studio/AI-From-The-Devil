using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject playerInventory;

    void Start()
    {
        playerInventory.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            playerInventory.SetActive(!playerInventory.activeSelf);
        }
    }
}