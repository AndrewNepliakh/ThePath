using UI;
using Zenject;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class BattleSceneManager : MonoBehaviour
    {
        [Inject] private IUIManager _uiManager;

        [Inject] private StateMachine<BattleStates> _gameStateMachine;

        [SerializeField] private Canvas _mainCanvas;

        private readonly BattleStates _startGameState = BattleStates.Setup;

        [Inject]
        private void Instantiation(
            SetupBattleState setupBattleState, 
            ChoiceActionBattleState choiceActionBattleState,
            ActionBattleState actionBattleState,
            ResultBattleState resultBattleState)
        {
            _uiManager.Init(_mainCanvas);
            
            _gameStateMachine.AddState(setupBattleState);
            _gameStateMachine.AddState(choiceActionBattleState);
            _gameStateMachine.AddState(actionBattleState);
            _gameStateMachine.AddState(resultBattleState);

            _gameStateMachine.ChangeState(_startGameState);
        }
    }
}