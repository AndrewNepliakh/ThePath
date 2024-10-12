using System.Linq;
using System.Threading.Tasks;
using Managers;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class ChoiceActionBattleStateController : IBattleStateController
    {
        [Inject] private BattleSceneManager _battleSceneManager;
        [Inject] private ChoiceActionBattleState _state;
        [Inject] private IUIManager _uiManager;
        
        private IAIChoiceManager _iaiChoiceManager;
        private IChoiceResulter _choiceResulter;
        
        private ChooseActionWindow _actionWindow;
        private ResultWindow _resultWindow;
        
        public async Task Init()
        {
            var opponentUnitsCount = _battleSceneManager.Level.Units.opponentUnits.Length;
            _iaiChoiceManager = new IaiChoiceManager(opponentUnitsCount);
            _choiceResulter = new ChoiceResulter();
            
            _actionWindow = await _uiManager.ShowWindow<ChooseActionWindow>();
            _actionWindow.OnChooseAction += ProceedAction;
        }
        
        private async void ProceedAction(ActionType choice)
        {
            var playerUnits = _battleSceneManager.Level.Units.playerUnits;
            
            if (playerUnits.Any(unit => unit.ActionChoice == ActionType.None))
            {
                playerUnits.First(unit => unit.ActionChoice == ActionType.None).ActionChoice = choice;
                if(playerUnits.Any(unit => unit.ActionChoice == ActionType.None)) return;
            }
            
            var opponentUnits = _battleSceneManager.Level.Units.opponentUnits;
            
            var aiChoice = _iaiChoiceManager.GetChoices();
            var result = _choiceResulter.GetResult(choice, aiChoice);
        
            var args = new ResultWindowArguments
            {
                Message = result + " Opponent choose " + aiChoice + 
                          " , You choose " + choice
            };
            
            _resultWindow = await _uiManager.ShowWindow<ResultWindow>(args);
            _resultWindow.OnContinueClicked += OnStateComplete;
        }
        
        private void OnStateComplete()
        {
            _state.OnStateComplete?.Invoke();
            _resultWindow.OnContinueClicked -= OnStateComplete;
            _actionWindow.OnChooseAction -= ProceedAction;
        }
    }
}