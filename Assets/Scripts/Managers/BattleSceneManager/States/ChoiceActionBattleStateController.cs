using System.Threading.Tasks;
using Managers;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class ChoiceActionBattleStateController : IBattleStateController
    {
        [Inject] private ChoiceActionBattleState _state;
        [Inject] private IGameManager _gameManager;
        [Inject] private IUIManager _uiManager;
        
        private IAIChoiceManager _iaiChoiceManager;
        private IChoiceResulter _choiceResulter;
        
        private ChooseActionWindow _actionWindow;
        private ResultWindow _resultWindow;
        
        public async Task Init()
        {
            _iaiChoiceManager = new IaiChoiceManager(_gameManager.UnitsData.opponentUnits);
            _choiceResulter = new ChoiceResulter();
            
            _actionWindow = await _uiManager.ShowWindow<ChooseActionWindow>();
            _actionWindow.OnChooseAction += ProceedAction;
        }
        
        private async void ProceedAction(ActionChoice choice)
        {
            var aiChoices = _iaiChoiceManager.GetChoices();
            var result = _choiceResulter.GetResult(choice.ActionChoices, aiChoices.ActionChoices);
        
            var args = new ResultWindowArguments
            {
                Message = result + " Opponent choose " + aiChoices.ActionChoices[0] + 
                          " , You choose " + choice.ActionChoices[0]
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