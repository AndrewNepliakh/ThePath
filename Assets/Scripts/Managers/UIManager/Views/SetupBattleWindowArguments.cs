using Controllers;
using Managers;

namespace UI
{
    public class SetupBattleWindowArguments : UIViewArguments
    {
        public SetupBattleState SetupBattleState;
        public ILevelManager LevelManager;
        public IUnitsManager UnitsManager;
    }
}