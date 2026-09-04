using UnityEngine;

[CreateAssetMenu(fileName = "NewInteractionData", menuName = "Game/InteractionData")]
public class InteractionData : ScriptableObject
{
    [SerializeField] private string _displayText;
    [SerializeField] private string _actionID;

    public string DisplayText => _displayText;
    public string ActionID => _actionID;
}
