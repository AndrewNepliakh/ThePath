namespace Controllers
{
    public interface IChoiceResulter
    {
        string GetResult(ActionType[] playerChoices, ActionType[] aiChoices);
    }
}