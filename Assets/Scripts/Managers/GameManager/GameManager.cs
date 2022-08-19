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
        
        private int _aiAmount = 1;
    }
}