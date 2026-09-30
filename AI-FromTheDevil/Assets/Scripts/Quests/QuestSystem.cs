using System.Collections.Generic;
using UnityEngine;

// Manager: bridges the ScriptableObject event channel and the pure-C# quests.
// The ONLY MonoBehaviour in the quest system: everything else is plain C#.
public class QuestSystem : MonoBehaviour
{
    [SerializeField] private InteractionEvents _interactionEventsChannel;

    private readonly List<Quest> _activeQuests = new List<Quest>();

    private void OnEnable()
    {
        _interactionEventsChannel.OnInteracted += HandleInteracted;
    }

    private void OnDisable()
    {
        _interactionEventsChannel.OnInteracted -= HandleInteracted;
    }

    private void Start()
    {
        // MVP: one hardcoded test quest. Data-driven (ScriptableObject) versions come later.
        Quest openDoor = new Quest(
            "First steps",
            "Open the door.",
            new List<QuestObjective> { new InteractObjective("OPEN_THE_DOOR") });
        openDoor.Completed += HandleQuestCompleted;
        _activeQuests.Add(openDoor);
    }

    private void HandleInteracted(InteractionData data)
    {
        if (data == null)
        {
            return;
        }

        // Copy: completing a quest removes it from the list mid-loop.
        foreach (Quest quest in new List<Quest>(_activeQuests))
        {
            quest.ReportProgress(data.ActionID);
        }
    }

    private void HandleQuestCompleted(Quest quest)
    {
        quest.Completed -= HandleQuestCompleted;
        _activeQuests.Remove(quest);
        Debug.Log($"[QuestSystem] Quest '{quest.Title}' completed!");
    }
}
