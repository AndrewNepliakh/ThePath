
namespace Managers
{
    public class GameManager : IGameManager
    {
        public UnitsData UnitsData => new UnitsData {playerUnits = 2, opponentUnits = 1};
    }
}