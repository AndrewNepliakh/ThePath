﻿using Managers;

public class ResultBattleState : IState<BattleStates>
{
    public BattleStates State => BattleStates.Result;
    public void Enter(ChangeStateData changeStateData = null)
    {
        throw new System.NotImplementedException();
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