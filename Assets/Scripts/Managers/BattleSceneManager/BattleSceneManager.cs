using Managers;
using UI;
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