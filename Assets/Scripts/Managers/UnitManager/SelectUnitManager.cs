using Zenject;

namespace Managers
{
    public class SelectUnitManager : ISelectUnitManager
    {
        [Inject] private IUnitsManager _unitsManager;
        
        private Unit _selectedUnit;
        
        public Unit SelectedUnit => _selectedUnit;
        
        public void SelectUnit(Unit unit, bool state = true)
        {
            _selectedUnit = unit;
            _selectedUnit.SetSelectAura(state);
        }
    }
}