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
