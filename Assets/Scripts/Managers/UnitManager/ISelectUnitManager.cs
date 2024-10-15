using System;
using Signals;

namespace Managers
{
    public interface ISelectUnitManager
    {
        public Unit SelectedUnit { get; }
        void RunPlayerUnitsSelectionQueue();
        void NextPlayerUnitsSelectionQueue(IUnitSelectableSignal signal);
    }
}