using Zenject;
using Managers;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace UI
{
    public class SetupBattleWindow : Window
    {
        [Inject] private ILevelManager _levelManager;
        [Inject] private IUnitsManager _unitsManager;
        [Inject] private SetupBattleState _state;
        
        private List<Cover> _covers;
    
        private List<ChooseCoverButton> _buttons = new();
    
        public override void Show(UIViewArguments arguments)
        {
            base.Show(arguments);
            _covers = _levelManager.CurrentLevel.Covers;
             SetChooseCoverButton();
        }
    
        private async void SetChooseCoverButton()
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
                button.SetPosition(cover, transform.GetComponent<RectTransform>());
                button.OnButtonClicked += SetUnitAtCover;
                _buttons.Add(button);
            }
        }
    
        private void SetUnitAtCover(Vector3 position)
        {
            var playerUnits = _unitsManager.PlayerUnits;
                
            if (playerUnits.Any(unit => unit.IsSetCoverPosition is false))
            {
                var playerUnit = playerUnits.First(unit => unit.IsSetCoverPosition is false);
                playerUnit.SetCoverPosition(position);
                if(playerUnits.Any(unit => unit.IsSetCoverPosition is false)) return;
            }
    
            foreach (var button in _buttons)
            {
                button.OnButtonClicked -= SetUnitAtCover;
                button.gameObject.SetActive(false);
            }
            
            _state.OnStateComplete?.Invoke();
        }
    }
}
