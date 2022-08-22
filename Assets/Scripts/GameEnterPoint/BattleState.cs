using System.Threading.Tasks;

namespace Managers
{
    public class BattleState : IState<GameStates>
    {
        
        public GameStates State { get; }
        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public Task Enter(ChangeStateData changeStateData)
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
}