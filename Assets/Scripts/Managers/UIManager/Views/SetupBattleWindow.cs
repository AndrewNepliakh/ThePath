using System.Collections.Generic;
using System.Linq;
using Controllers;
using Managers;
using UnityEngine;

public class SetupBattleWindow : Window
{
    private BattleSceneManager _battleSceneManager;
    private SetupBattleState _state;
    private List<Cover> _covers;

    private List<ChooseCoverButton> _buttons = new();

    public override void Show(UIViewArguments arguments)
    {
        base.Show(arguments);

        _battleSceneManager = ((SetupBattleWindowArguments) arguments).BattleSceneManager;
        _state = ((SetupBattleWindowArguments) arguments).SetupBattleState;
        _covers = _battleSceneManager.Level.Covers;

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
        var playerUnits = _battleSceneManager.Level.Units.playerUnits;
            
        if (playerUnits.Any(unit => unit.IsSetStartPosition is false))
        {
            var playerUnit = playerUnits.First(unit => unit.IsSetStartPosition is false);
            playerUnit.SetStartPosition(position);
            if(playerUnits.Any(unit => unit.IsSetStartPosition is false)) return;
        }

        foreach (var button in _buttons)
        {
            button.OnButtonClicked -= SetUnitAtCover;
            button.gameObject.SetActive(false);
        }
        
        _state.OnStateComplete?.Invoke();
    }
}