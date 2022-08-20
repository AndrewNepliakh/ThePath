using System;

namespace Managers
{
    public class GameManager : IGameManager
    {
        public int AIAmount
        {
            get
            {
                return _aiAmount > 0 ? _aiAmount : 1;
            }
        }

        public string LevelID {
            get
            {
                if (_levelID != String.Empty) return _levelID;
                else return "Level_1";
            }
        }

        private int _aiAmount = 1;
        private string _levelID = "Level_1";
        
    }
}