using System;
using Controllers;
using UI;

namespace Signals
{
    public class SetUnitActionSignal : IUnitSelectableSignal
    {
        private ActionType _actionChoice;
        private ChooseActionWindow _actionWindow;
        public SetUnitActionSignal(ActionType actionChoice, ChooseActionWindow actionWindow)
        {
            _actionChoice = actionChoice;
            _actionWindow = actionWindow;
        }

        public Action<Unit> OnSelect => (unit) => unit.SetActionChoice(_actionChoice);
        public Action OnQueueEnd => () => _actionWindow.SwitchButtonContainers(ActionButtonContainerType.EndActionPhase);
    }
}