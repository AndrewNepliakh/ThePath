
namespace Managers
{
    public class GameManager : IGameManager
    {
        public UnitsData UnitsData => new UnitsData {playerUnits = 5, opponentUnits = 1};
    }
}