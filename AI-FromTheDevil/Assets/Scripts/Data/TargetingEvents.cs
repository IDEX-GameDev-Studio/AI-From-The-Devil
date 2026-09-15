using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetingEvents", menuName = "Scriptable Objects/TargetingEvents")]
public class TargetingEvents : ScriptableObject
{
    private event Action<InteractionData> _OnTargeted;
    private event Action<InteractionData> _OnExit;
    public event Action<InteractionData> OnTargeted
    {
        add => _OnTargeted += value;
        remove => _OnTargeted -= value;
    }
    public event Action<InteractionData> OnExit
    {
        add => _OnExit += value;
        remove => _OnExit -= value;
    }
    public void Raise(InteractionData interactionData)
    {
        _OnTargeted?.Invoke(interactionData);
    }
    public void RaiseExit(InteractionData interactionData)
    {
        _OnExit?.Invoke(interactionData);
    }
}
