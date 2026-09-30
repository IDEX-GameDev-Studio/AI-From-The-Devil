using System;
using System.Collections.Generic;

// A quest: a bag of objectives plus a completion callback.
// Plain C# class: no MonoBehaviour, no ScriptableObject, no Unity types.
// The ONLY thing it understands is action ID strings.
public class Quest
{
    public string Title { get; }
    public string Description { get; }
    public bool IsCompleted { get; private set; }

    public event Action<Quest> Completed;

    private readonly List<QuestObjective> _objectives;

    public Quest(string title, string description, List<QuestObjective> objectives)
    {
        Title = title;
        Description = description;
        _objectives = objectives;
    }

    // Feed one interaction ID through every objective.
    // Fires Completed exactly once, on the call that closes the last objective.
    public void ReportProgress(string actionId)
    {
        if (IsCompleted)
        {
            return;
        }

        foreach (QuestObjective objective in _objectives)
        {
            objective.CheckProgress(actionId);
        }

        foreach (QuestObjective objective in _objectives)
        {
            if (!objective.IsCompleted)
            {
                return;
            }
        }

        IsCompleted = true;
        Completed?.Invoke(this);
    }
}
