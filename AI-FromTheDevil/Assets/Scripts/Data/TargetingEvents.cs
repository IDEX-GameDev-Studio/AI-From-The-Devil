using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetingEvents", menuName = "Scriptable Objects/TargetingEvents")]
public class TargetingEvents : ScriptableObject
{
    // A plain event already forbids outside Invoke: only += and -= are visible externally.
    public event Action<InteractionData> OnTargeted;
    public event Action<InteractionData> OnExit;

    public void Raise(InteractionData interactionData)
    {
        OnTargeted?.Invoke(interactionData);
    }
    public void RaiseExit(InteractionData interactionData)
    {
        OnExit?.Invoke(interactionData);
    }
}
