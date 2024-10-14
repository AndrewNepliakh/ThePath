using UI;
using Zenject;
using Managers;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    public class ChoiceActionBattleStateController : IBattleStateController
    {
        [Inject] private ChoiceActionBattleState _state;
        [Inject] private IUnitsManager _unitsManager;
        [Inject] private IUIManager _uiManager;
        
        private IAIChoiceManager _iaiChoiceManager;
        private IChoiceResulter _choiceResulter;
        
        private ChooseActionWindow _actionWindow;
        private ResultWindow _resultWindow;
        
        public async Task Init()
        {
            var opponentUnitsCount = _unitsManager.OpponentUnits.Length;
            _iaiChoiceManager = new IaiChoiceManager(opponentUnitsCount);
            _choiceResulter = new ChoiceResulter();
            
            _actionWindow = await _uiManager.ShowWindow<ChooseActionWindow>();
            _actionWindow.OnChooseAction += ProceedAction;
            _actionWindow.OnConfirmActionPhase += ConfirmActionPhase;
        }
        
        private void ProceedAction(ActionType choice)
        {
            var playerUnits = _unitsManager.PlayerUnits;
            
            if (playerUnits.Any(unit => unit.ActionChoice == ActionType.None))
            {
                playerUnits.First(unit => unit.ActionChoice == ActionType.None).SetActionChoice(choice);
                if(playerUnits.Any(unit => unit.ActionChoice == ActionType.None)) return;
            }

            _actionWindow.SwitchButtonContainers(ActionButtonContainerType.EndActionPhase);
        }

        private async void ConfirmActionPhase()
        {
            var playerUnits = _unitsManager.PlayerUnits;
            var opponentUnits = _unitsManager.OpponentUnits;
            
            var aiChoice = _iaiChoiceManager.GetChoices();
            var result = _choiceResulter.GetResult(playerUnits[0].ActionChoice, aiChoice);
        
            var args = new ResultWindowArguments
            {
                Message = result + " Opponent choose " + aiChoice + 
                          " , You choose " + playerUnits[0].ActionChoice
            };
            
            _resultWindow = await _uiManager.ShowWindow<ResultWindow>(args);
            _resultWindow.OnContinueClicked += OnStateComplete;
        }

        private void OnStateComplete()
        {
            _state.OnStateComplete?.Invoke();
            _resultWindow.OnContinueClicked -= OnStateComplete;
            _actionWindow.OnChooseAction -= ProceedAction;
            _actionWindow.OnConfirmActionPhase -= ConfirmActionPhase;
        }
    }
}