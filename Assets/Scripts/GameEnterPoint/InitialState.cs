using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Managers
{
    public class InitialState : IState<GameStates>
    {
        public GameStates State { get; }
        public void Enter()
        {
            throw new NotImplementedException();
        }

        public void Enter(ChangeStateData changeStateData)
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}