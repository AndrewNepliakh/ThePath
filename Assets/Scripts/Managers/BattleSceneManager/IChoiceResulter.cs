namespace Controllers
{
    public interface IChoiceResulter
    {
        string GetResult(ActionType playerChoice, ActionType aiChoice);
    }
}