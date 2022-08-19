using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class AIChoiceController : IAIChoiceController
    {
        private readonly ActionType[] _aiChoices; 
            
        public AIChoiceController(int aiAmount)
        {
            _aiChoices = new ActionType[aiAmount];
        }

        public ActionChoice GetChoices()
        {
            for (var i = 0; i < _aiChoices.Length; i++)
            {
                _aiChoices[i] = (ActionType)Random.Range(0, 3);
            }

            return new ActionChoice {ActionChoices = _aiChoices};
        }
    }
}