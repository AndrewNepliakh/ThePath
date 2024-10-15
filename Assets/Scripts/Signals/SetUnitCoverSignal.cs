using System;
using UnityEngine;

namespace Signals
{
    public class SetUnitCoverSignal : IUnitSelectableSignal
    {
        private SetupBattleState _setupBattleState;
        
        private Vector3 _position;

        public SetUnitCoverSignal(Vector3 position, SetupBattleState setupBattleState)
        {
            _position = position;
            _setupBattleState = setupBattleState;
        }

        public Action<Unit> OnSelect  => (unit) => unit.SetCoverPosition(_position);
        public Action OnQueueEnd => () => _setupBattleState.OnStateComplete?.Invoke();
    }
}