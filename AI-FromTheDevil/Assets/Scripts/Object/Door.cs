using UnityEngine;

public class Door : InteractableObject
{
    [SerializeField] private InteractionEvents _interactionEvents;
    [SerializeField] private InteractionData _interactionData;
    public override void Interact()
    {
        Debug.Log("Door opened");
        _interactionEvents.Raise(_interactionData);
    }
    private void OnValidate()
    {
        if (_interactionData == null)
        {
            Debug.LogWarning($"{name}: InteractionData не назначен.", this);
        }
    }
}

