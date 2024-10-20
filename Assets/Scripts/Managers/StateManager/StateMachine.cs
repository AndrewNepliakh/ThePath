using System;
using System.Collections.Generic;

namespace Managers
{
    public abstract class StateMachine<T> where T : Enum
    {
        public T CurrentState => (_currentState != null) ? _currentState.State : default;
        public T PreviousState => (_previousState != null) ? _previousState.State : default;
        public event Action OnChangeState;
        public event Action OnAfterChangeState;

        protected IState<T> _currentState;
        protected IState<T> _previousState;

        protected readonly Dictionary<T, IState<T>> _states = new Dictionary<T, IState<T>>();

        public StateMachine() { }
        
        public void AddState(IState<T> state)
        {
            _states.Add(state.State, state);
        }

        public void ChangeState(T newState)
        {
            _currentState?.Exit();

            _previousState = _currentState;
            _currentState = _states[newState];
            OnChangeState?.Invoke();

            _currentState.Enter();

            OnAfterChangeState?.Invoke();
        }
        
        public void ChangeState(T newState, ChangeStateData changeStateData)
        {
            _currentState?.Exit();

            _previousState = _currentState;
            _currentState = _states[newState];
            OnChangeState?.Invoke();

            _currentState.Enter(changeStateData);

            OnAfterChangeState?.Invoke();
        }

        public void Update(float deltaTime)
        {
            _currentState?.Update(deltaTime);
        }

        public void ExitAllStates()
        {
            foreach (var state in _states.Values) state.Exit();
        }
    }
}