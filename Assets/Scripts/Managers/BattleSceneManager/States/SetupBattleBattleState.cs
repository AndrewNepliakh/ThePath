using System;
using Zenject;
using Managers;
using System.Threading.Tasks;


public class SetupBattleState :  IState<BattleStates>
{
    public BattleStates State => BattleStates.Setup;
    
    [Inject] private BattleSceneStateMachine<BattleStates> _battleStateMachine;
    [Inject] private SetupBattleStateController _controller;

    public Action OnStateComplete; 

    public async Task Enter(ChangeStateData changeStateData)
    {
        await _controller.Init();
        OnStateComplete += StateCompleteHandler;
    }
    
    private void StateCompleteHandler()
    {
        _battleStateMachine.ChangeState(BattleStates.ChoiceAction);
    }

    public void Exit()
    {
        OnStateComplete -= StateCompleteHandler;
    }

    public void Update(float deltaTime)
    {
    }
}