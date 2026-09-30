// Concrete objective: completes when the matching interaction happens.
// The ONLY class in the quest system that knows what an interaction is.
// The base class stays blind: it only ever sees a plain string.
public class InteractObjective : QuestObjective
{
    private readonly string _requiredActionID;

    public InteractObjective(string requiredActionID)
    {
        _requiredActionID = requiredActionID;
    }

    public override bool CheckProgress(string actionId)
    {
        if (IsCompleted)
        {
            return false;
        }

        if (actionId == _requiredActionID)
        {
            IsCompleted = true;
            return true;
        }

        return false;
    }
}
