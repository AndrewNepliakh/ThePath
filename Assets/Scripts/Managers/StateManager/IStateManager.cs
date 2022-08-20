using System.Collections;

namespace Managers
{
    public interface IStateManager
    {
        IState ActiveState { get; }
        IState EnterState<T>() where T : IState;
    }
}