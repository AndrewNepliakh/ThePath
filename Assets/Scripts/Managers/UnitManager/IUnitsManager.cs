using System.Threading.Tasks;

namespace Managers
{
    public interface IUnitsManager
    {
        public void Init(UnitsData unitsData);
        Task<UnitsList> InstantiateUnits();
    }
}