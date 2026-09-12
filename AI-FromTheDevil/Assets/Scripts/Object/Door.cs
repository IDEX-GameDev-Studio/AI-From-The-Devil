using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] private InteractionEvents _interactionEvents;
    public override void Interact()
    {
        Debug.Log("Door opened");
        _interactionEvents.Raise(InteractionData);
    }
    private void OnValidate()
    {
        if (InteractionData == null)
        {
            Debug.LogWarning($"{name}: InteractionData не назначен.", this);
        }
    }
}

