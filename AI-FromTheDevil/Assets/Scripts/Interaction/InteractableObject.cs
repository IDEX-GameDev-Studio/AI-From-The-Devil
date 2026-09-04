using UnityEngine;

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionData _interactionData;
    public InteractionData InteractionData => _interactionData;
    public abstract void Interact();
}
