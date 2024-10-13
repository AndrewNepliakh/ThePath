using System;

namespace UI
{
    public class BattleSceneWindowArguments : UIViewArguments
    {
        public Action<string> OnShow;
        public Action<string> OnClose;
    }
}