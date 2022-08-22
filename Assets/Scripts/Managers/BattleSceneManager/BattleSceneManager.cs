using System;
using JetBrains.Annotations;
using Managers;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class BattleSceneManager : MonoBehaviour
    {
        public Level Level => _level;

        [Inject] private ILevelManager _levelManager;
        [Inject] private IGameManager _gameManager;
        [Inject] private IUIManager _uiManager;

        [Inject] private StateMachine<BattleStates> _gameStateMachine;

        [SerializeField] private Canvas _mainCanvas;

        private readonly BattleStates _startGameState = BattleStates.Setup;
        private Level _level;
        public void SetLevel(Level level) => _level = level;

        [Inject]
        private void Instantiation(
            SetupBattleState setupBattleState, 
            ChoiceActionState choiceActionState,
            ActionBattleState actionBattleState,
            ResultBattleState resultBattleState)
        {
            _uiManager.Init(_mainCanvas);
            
            _gameStateMachine.AddState(setupBattleState);
            _gameStateMachine.AddState(choiceActionState);
            _gameStateMachine.AddState(actionBattleState);
            _gameStateMachine.AddState(resultBattleState);

            _gameStateMachine.ChangeState(_startGameState);
        }


        // private IAIChoiceManager _iaiChoiceManager;
        // private IChoiceResulter _choiceResulter;
        //
        // private ChooseActionWindow _actionWindow;
        // private ResultWindow _resultWindow;
        //
        //
        // private async void Awake()
        // {
        //     _iaiChoiceManager = new IaiChoiceManager(_gameManager.UnitsData.opponentUnits);
        //     _choiceResulter = new ChoiceResulter();
        //
        //     _uiManager.Init(_mainCanvas);
        //
        //     _actionWindow = await _uiManager.ShowWindow<ChooseActionWindow>();
        //     _actionWindow.OnChooseAction += ProceedAction;
        //
        //     InitLevel();
        // }
        //

        //
        // private async void ProceedAction(ActionChoice choice)
        // {
        //     var aiChoices = _iaiChoiceManager.GetChoices();
        //     var result = _choiceResulter.GetResult(choice.ActionChoices, aiChoices.ActionChoices);
        //
        //     var args = new ResultWindowArguments
        //     {
        //         Message = result + " Opponent choose " + aiChoices.ActionChoices[0] + 
        //                   " , You choose " + choice.ActionChoices[0]
        //     };
        //     
        //     _resultWindow = await _uiManager.ShowWindow<ResultWindow>(args);
        //     _resultWindow.OnContinueClicked += Continue;
        // }
        //
        // private async void Continue()
        // {
        //     await _uiManager.ShowWindow<ChooseActionWindow>();
        // }
    }
}