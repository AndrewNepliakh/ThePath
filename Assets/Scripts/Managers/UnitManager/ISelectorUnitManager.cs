using System;
using Signals;

namespace Managers
{
    public interface ISelectorUnitManager
    {
        public Unit SelectedUnit { get; }
        Action<Unit> OnSelectedUnitChanged { get; set; }
        void RunPlayerUnitsSelectionQueue();
        void NextPlayerUnitsSelectionQueue(IUnitSelectableSignal signal);
    }
}