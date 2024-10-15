using System;

namespace Signals
{
    public interface IUnitSelectableSignal
    {
        Action<Unit> OnSelect { get; }
        Action OnQueueEnd { get; }
    }
}