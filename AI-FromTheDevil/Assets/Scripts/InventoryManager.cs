using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [System.Serializable]
    public struct InventoryItem
    {
        public string name;
        public Sprite icon;
    }

    [Header("inventory")]
    public List<InventoryItem> inventoryList = new List<InventoryItem>();
    private int maxSlots = 4;

    [Header("slots")]
    public Image[] hotbarSlots;

    [Header("Selection Settings")]
    private int currentSelectedSlot = -1; // -1 означает, что ничего не выбрано
    public Color selectedColor = Color.green;  // Цвет подсветки
    public Color defaultColor = Color.white;   // Обычный цвет

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectSlot(3);
    }

    void SelectSlot(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= hotbarSlots.Length) return;

        currentSelectedSlot = slotIndex;

        if (slotIndex < inventoryList.Count)
        {
            Debug.Log("Item equipped from slot " + slotIndex + ": " + inventoryList[slotIndex].name);
        }
        else
        {
            Debug.Log("Equipped empty slot " + slotIndex);
        }

        UpdateSlotHighlights();
    }

    void UpdateSlotHighlights()
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            if (i == currentSelectedSlot)
            {
                hotbarSlots[i].color = selectedColor;
            }
            else
            {
                hotbarSlots[i].color = defaultColor;
            }
        }
    }

    public bool AddItem(string itemName, Sprite itemIcon)
    {
        if (inventoryList.Count >= maxSlots)
        {
            Debug.Log("NO SPACE LEFT");
            return false;
        }

        InventoryItem newItem;
        newItem.name = itemName;
        newItem.icon = itemIcon;
        inventoryList.Add(newItem);

        UpdateUI();
        return true;
    }

    void UpdateUI()
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            if (i < inventoryList.Count)
            {
                hotbarSlots[i].sprite = inventoryList[i].icon;
                hotbarSlots[i].enabled = true;
            }
            else
            {
                hotbarSlots[i].sprite = null;
                hotbarSlots[i].enabled = false;
            }
        }
        
        UpdateSlotHighlights();
    }

    public bool HasItem(string nameToCheck)
    {
        foreach (InventoryItem item in inventoryList)
        {
            if (item.name == nameToCheck) return true;
        }
        return false;
    }
}
