using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionEvents", menuName = "Scriptable Objects/InteractionEvents")]
public class InteractionEvents : ScriptableObject
{
    public Action<InteractionData> OnInteracted;

    public void Raise(InteractionData interactionData)
    {
        OnInteracted?.Invoke(interactionData);
    }
}
