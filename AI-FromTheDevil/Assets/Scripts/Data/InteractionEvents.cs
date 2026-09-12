using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionEvents", menuName = "Scriptable Objects/InteractionEvents")]
public class InteractionEvents : ScriptableObject
{
    private event Action<InteractionData> _OnInteracted;
    public event Action<InteractionData> OnInteracted
    {
        add => _OnInteracted += value;
        remove => _OnInteracted -= value;
    }

    public void Raise(InteractionData interactionData)
    {
        _OnInteracted?.Invoke(interactionData);
    }
}
