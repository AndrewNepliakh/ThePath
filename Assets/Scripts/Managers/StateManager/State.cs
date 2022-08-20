using System.Collections;

namespace Managers
{
    public abstract class State : IState
    {
        protected bool _isStarted;

        public abstract void Enter();
        public abstract void Exit();

        public virtual void Update()
        {
            if (!_isStarted) return;
        }
    }
}