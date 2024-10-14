using UI;
using Zenject;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class BattleSceneManager : MonoBehaviour
    {
        [Inject] private IUIManager _uiManager;

        [Inject] private BattleSceneStateMachine<BattleStates> _battleSceneStateMachine;

        [SerializeField] private Canvas _mainCanvas;

        [Inject]
        private void Instantiation(
            SetupBattleState setupBattleState, 
            ChoiceActionBattleState choiceActionBattleState,
            ActionBattleState actionBattleState,
            ResultBattleState resultBattleState)
        {
            _uiManager.Init(_mainCanvas);
            
            _battleSceneStateMachine.AddState(setupBattleState);
            _battleSceneStateMachine.AddState(choiceActionBattleState);
            _battleSceneStateMachine.AddState(actionBattleState);
            _battleSceneStateMachine.AddState(resultBattleState);

            _battleSceneStateMachine.ChangeState(BattleStates.Setup);
        }
    }
}