using System;
using System.Threading.Tasks;

namespace Managers
{
    public class InitialState : IState<GameStates>
    {
        public GameStates State { get; }
        public void Enter()
        {
            throw new NotImplementedException();
        }

        public Task Enter(ChangeStateData changeStateData)
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