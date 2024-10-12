using Random = UnityEngine.Random;

namespace Controllers
{
    public class IaiChoiceManager : IAIChoiceManager
    {
        private readonly ActionType[] _aiChoices; 
            
        public IaiChoiceManager(int aiAmount)
        {
            _aiChoices = new ActionType[aiAmount];
        }

        public ActionType GetChoices()
        {
            return (ActionType)Random.Range(0, 3);
        }
    }
}