using Zenject;
using Signals;
using Managers;
using UnityEngine;
using System.Collections.Generic;

namespace UI
{
    public class SetupBattleWindow : Window
    {
        [Inject] private ISelectorUnitManager _selectorUnitManager;
        [Inject] private ILevelManager _levelManager;
        [Inject] private IUnitsManager _unitsManager;
        [Inject] private SetupBattleState _setupBattleState;
        [Inject] private SignalBus _signalBus;

        private List<Cover> _covers;

        private List<ChooseCoverButton> _buttons = new();

        public override void Show(UIViewArguments arguments)
        {
            base.Show(arguments);
            _covers = _levelManager.CurrentLevel.Covers;
            SetChooseCoverButtons();
        }

        private async void SetChooseCoverButtons()
        {
            var availableCovers = new List<Cover>();

            foreach (var cover in _covers)
            {
                if (cover.transform.position.z <= 5.0f)
                    availableCovers.Add(cover);
            }

            foreach (var cover in availableCovers)
            {
                var assetLoader = new AssetsLoader();
                var button = await assetLoader.InstantiateAsset<ChooseCoverButton>(transform, true);
                button.Init(assetLoader);
                button.SetPosition(cover, transform.GetComponent<RectTransform>());
                button.OnButtonClicked += SetUnitAtCover;
                _buttons.Add(button);
            }
        }

        private void SetUnitAtCover(Vector3 position) =>
            _signalBus.AbstractFire(new SetUnitCoverSignal(position, _setupBattleState));
    }
}