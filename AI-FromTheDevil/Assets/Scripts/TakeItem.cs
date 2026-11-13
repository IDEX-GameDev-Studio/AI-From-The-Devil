using UnityEngine;
public class TakeItem : MonoBehaviour
{
    public GameObject playerInventory;
    public void Take()
    {
        transform.SetParent(playerInventory.transform);
        Debug.Log("Предмет взято");
    }
}