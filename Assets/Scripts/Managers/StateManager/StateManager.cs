using System;
using System.Collections;
using System.Collections.Generic;
using Zenject;

namespace Managers
{
    public class StateManager : IStateManager
    {
        public IState ActiveState => _activeState;
        
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        [Inject]
        public StateManager(IState initialState, IState gameState)
        {
            _states = new Dictionary<Type, IState>
            {
                {typeof(InitialState), initialState},
                {typeof(BattleState), gameState}
            };
        }

        public IState EnterState<T>() where T : IState
        {
            _activeState?.Exit();
            var state = _states[typeof(T)];
            _activeState = state;
            state.Enter();
            return state;
        }
    }
}