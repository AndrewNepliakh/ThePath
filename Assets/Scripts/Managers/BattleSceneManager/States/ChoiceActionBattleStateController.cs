using UI;
using Zenject;
using Managers;
using System.Linq;
using System.Threading.Tasks;
using Signals;

namespace Controllers
{
    public class ChoiceActionBattleStateController : IBattleStateController
    {
        [Inject] private ChoiceActionBattleState _state;
        [Inject] private ISelectorUnitManager _selectorUnitManager;
        [Inject] private IUnitsManager _unitsManager;
        [Inject] private IUIManager _uiManager;
        [Inject] private SignalBus _signalBus;

        private IAIChoiceManager _iaiChoiceManager;
        private IChoiceResulter _choiceResulter;

        private ChooseActionWindow _actionWindow;
        private ResultWindow _resultWindow;

        public async Task Init()
        {
            SetAIChoiceManager();
            await ShowChooseActionWindow();
            _selectorUnitManager.RunPlayerUnitsSelectionQueue();
        }

        private void SetAIChoiceManager()
        {
            var opponentUnitsCount = _unitsManager.OpponentUnits.Length;
            _iaiChoiceManager = new IaiChoiceManager(opponentUnitsCount);
            _choiceResulter = new ChoiceResulter();
        }

        private async Task ShowChooseActionWindow()
        {
            _actionWindow = await _uiManager.ShowWindow<ChooseActionWindow>();
            _actionWindow.OnChooseAction += ProceedAction;
            _actionWindow.OnConfirmActionPhase += ConfirmActionPhase;
        }

        private void ProceedAction(ActionType choice) =>
            _signalBus.AbstractFire(new SetUnitActionSignal(choice, _actionWindow));

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