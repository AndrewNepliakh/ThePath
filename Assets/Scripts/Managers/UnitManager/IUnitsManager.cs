using System.Threading.Tasks;

namespace Managers
{
    public interface IUnitsManager
    {
        public Unit[] PlayerUnits { get; }
        public Unit[] OpponentUnits { get; }

        void Init(UnitsData unitsData);
        Task InstantiateUnits();
    }
}