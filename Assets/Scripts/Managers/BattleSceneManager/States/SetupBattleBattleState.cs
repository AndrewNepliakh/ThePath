using Managers;
using UnityEngine;
using Zenject;


public class SetupBattleState :  IState<BattleStates>
{
    public BattleStates State => BattleStates.Setup;
    
    [Inject] private StateMachine<BattleStates> _battleStateMachine;
    
    public void Enter(ChangeStateData changeStateData)
    {
       StateCompleteHandler();
    }
    
    private void StateCompleteHandler()
    {
        _battleStateMachine.ChangeState(BattleStates.ChoiceAction);
    }

    public void Exit()
    {
    }

    public void Update(float deltaTime)
    {
    }

    public void Dispose()
    {
    }
}