using System.Threading.Tasks;

namespace Managers
{
    public interface IUnitsManager
    {
        public Unit[] PlayerUnits { get; }
        public Unit[] OpponentUnits { get; }
        Task InstantiateUnits();
    }
}