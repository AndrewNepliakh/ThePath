using System;

namespace Managers
{
    public class BattleSceneWindowArguments : UIViewArguments
    {
        public Action<string> OnShow;
        public Action<string> OnClose;
    }
}