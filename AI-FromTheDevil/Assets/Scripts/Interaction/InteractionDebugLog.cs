using UnityEngine;

// TEMPORARY debug listener for the interaction event channels.
// Attach to any GameObject in the test scene, assign both channels,
// open the Console and verify: look -> "Targeted", look away -> "Untargeted",
// press E -> "Interacted". Reload with R: every line must appear ONCE.
public class InteractionDebugLog : MonoBehaviour
{
    [SerializeField] private TargetingEvents _targetingEvents;
    [SerializeField] private InteractionEvents _interactionEvents;

    private void OnEnable()
    {
        _targetingEvents.OnTargeted += HandleTargeted;
        _targetingEvents.OnExit += HandleExit;
        _interactionEvents.OnInteracted += HandleInteracted;
    }

    private void OnDisable()
    {
        _targetingEvents.OnTargeted -= HandleTargeted;
        _targetingEvents.OnExit -= HandleExit;
        _interactionEvents.OnInteracted -= HandleInteracted;
    }

    private void HandleTargeted(InteractionData data)
    {
        Debug.Log($"Targeted: {data.DisplayText}");
    }

    private void HandleExit(InteractionData data)
    {
        Debug.Log($"Untargeted: {data.DisplayText}");
    }

    private void HandleInteracted(InteractionData data)
    {
        Debug.Log($"Interacted: {data.ActionID}");
    }
}
