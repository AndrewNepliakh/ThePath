using System;
using System.Linq;
using Signals;
using Zenject;

namespace Managers
{
    public class SelectorUnitManager : ISelectorUnitManager, IInitializable
    {
        [Inject] private IUnitsManager _unitsManager;
        [Inject] private SignalBus _signalBus;
        
        private Unit _selectedUnit;
        
        public Unit SelectedUnit => _selectedUnit;

        public Action<Unit> OnSelectedUnitChanged { get; set; }

        public void Initialize()
        {
            _signalBus.Subscribe<IUnitSelectableSignal>(NextPlayerUnitsSelectionQueue);
        }

        public void RunPlayerUnitsSelectionQueue()
        {
            var playerUnits = _unitsManager.PlayerUnits;

            foreach (var unit in playerUnits)
            {
                unit.SetSelectAura(false);
                unit.IsPassedSelectionQueue = false;
            }
            
            _selectedUnit = playerUnits.First(unit => unit.IsPassedSelectionQueue is false);
            _selectedUnit.SetSelectAura(true);
            
            OnSelectedUnitChanged?.Invoke(_selectedUnit);
        }

        public void NextPlayerUnitsSelectionQueue(IUnitSelectableSignal signal)
        {
            signal.OnSelect?.Invoke(_selectedUnit);
            _selectedUnit.SetSelectAura(false);
            _selectedUnit.IsPassedSelectionQueue = true;
            
            var playerUnits = _unitsManager.PlayerUnits;
            
            if (playerUnits.Any(unit => unit.IsPassedSelectionQueue is false))
            {
                _selectedUnit = playerUnits.First(unit => unit.IsPassedSelectionQueue is false);
                OnSelectedUnitChanged?.Invoke(_selectedUnit);
                _selectedUnit.SetSelectAura(true);
                return;
            }

            signal.OnQueueEnd?.Invoke();
        }
    }
}