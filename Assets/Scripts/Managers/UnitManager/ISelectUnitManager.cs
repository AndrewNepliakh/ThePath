namespace Managers
{
    public interface ISelectUnitManager
    {
        public Unit SelectedUnit { get; }
        void SelectUnit(Unit unit, bool state = true);
    }
}