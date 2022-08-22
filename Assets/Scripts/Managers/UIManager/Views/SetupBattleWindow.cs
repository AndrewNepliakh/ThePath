﻿using System.Collections.Generic;
using Controllers;
using Managers;
using UnityEngine;
using Zenject;


public class SetupBattleWindow : Window
{
    private BattleSceneManager _battleSceneManager;

    private Unit _player;
    private List<Cover> _covers;

    private List<ChooseCoverButton> _buttons = new();

    public override async void Show(UIViewArguments arguments)
    {
        base.Show(arguments);

        _battleSceneManager = ((SetupBattleWindowArguments) arguments).BattleSceneManager;
        
        _player = _battleSceneManager.Level.Units.playerUnits[0];
        _covers = _battleSceneManager.Level.Covers;

        var availableCovers = new List<Cover>();

        foreach (var cover in _covers)
        {
            if (cover.transform.position.z <= 5.0f)
                availableCovers.Add(cover);
        }

        foreach (var cover in availableCovers)
        {
            var assetLoader = new AssetsLoader();
            var button = await assetLoader.InstantiateAsset<ChooseCoverButton>(transform);
            button.SetPosition(cover.transform);
            button.OnButtonClicked(SetUnitAtCover);
            _buttons.Add(button);
        }
    }

    private void SetUnitAtCover(Vector3 position)
    {
        _player.transform.position = position;
    }
}