namespace Controllers
{
    public class ActionChoice
    {
        public ActionType[] ActionChoices;
    }

    public enum ActionType
    {
        Attack,
        Move, 
        Cover
    }
}