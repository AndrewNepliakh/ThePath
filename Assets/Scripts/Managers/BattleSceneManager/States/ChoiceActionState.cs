using Managers;
using UnityEngine;
using Zenject;


public class ChoiceActionState : IState<BattleStates>
{
    public BattleStates State => BattleStates.ChoiceAction;
    [Inject] private StateMachine<BattleStates> _battleStateMachine;
    
    public void Enter(ChangeStateData changeStateData = null)
    {
        Debug.Log("Hello!!!");
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Update(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }
}