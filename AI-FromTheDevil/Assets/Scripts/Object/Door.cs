using UnityEngine;

public class Door : InteractableObject
{
    public override void Interact()
    {
        Debug.Log("Door opened");
    }
    private void OnValidate()
    {
        if (InteractionData == null)
        {
            Debug.LogWarning($"{name}: InteractionData �� ��������.", this);
        }
    }
}

