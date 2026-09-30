// Abstract quest goal.
// Knows nothing about interaction, Unity, or event payloads:
// progress arrives as a plain action ID string.
public abstract class QuestObjective
{
    public bool IsCompleted { get; protected set; }

    // Returns true the moment this call completes the objective.
    // Returning the fact (instead of void) lets Quest react immediately.
    public abstract bool CheckProgress(string actionId);
}
