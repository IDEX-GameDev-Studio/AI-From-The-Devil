using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionEvents", menuName = "Scriptable Objects/InteractionEvents")]
public class InteractionEvents : ScriptableObject
{
    // A plain event already forbids outside Invoke: only += and -= are visible externally.
    public event Action<InteractionData> OnInteracted;

    public void Raise(InteractionData interactionData)
    {
        OnInteracted?.Invoke(interactionData);
    }
}
