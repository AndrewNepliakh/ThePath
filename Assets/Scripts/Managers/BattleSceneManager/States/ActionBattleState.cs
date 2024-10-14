using System.Threading.Tasks;
using Managers;

public class ActionBattleState : IState<BattleStates>
{
    public BattleStates State => BattleStates.Action;
    public Task Enter(ChangeStateData changeStateData = null)
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
}