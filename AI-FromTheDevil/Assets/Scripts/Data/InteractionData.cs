using UnityEngine;

[CreateAssetMenu(fileName = "InteractionData", menuName = "Game/InteractionData")]
public class InteractionData : ScriptableObject
{
    [SerializeField] private string _displayText;
    [SerializeField] private string _actionID;

    public string DisplayText => _displayText;
    public string ActionID => _actionID;
}
