using System;

namespace Managers
{
    public class GameManager : IGameManager
    {
        public UnitsData UnitsData => new UnitsData {playerUnits = 1, opponentUnits = 1};
    }
}