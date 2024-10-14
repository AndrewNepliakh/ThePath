using System;
using System.Threading.Tasks;
using Controllers;
using Managers;
using Zenject;


public class ChoiceActionBattleState : IState<BattleStates>
{
    public BattleStates State => BattleStates.ChoiceAction;
    public Action OnStateComplete;

    [Inject] private StateMachine<BattleStates> _battleStateMachine;
    [Inject] private ChoiceActionBattleStateController _controller;
    
    public async Task Enter(ChangeStateData changeStateData = null)
    {
        await _controller.Init();
        OnStateComplete += StateCompleteHandler;
    }
    
    private void StateCompleteHandler()
    { 
       _battleStateMachine.ChangeState(BattleStates.Setup);
    }

    public void Exit()
    {
        OnStateComplete -= StateCompleteHandler;
    }

    public void Update(float deltaTime)
    {
       
    }

    public void Dispose()
    {
       
    }
}