using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using Zenject;

public abstract class Level : MonoBehaviour, ILevel
{
    public List<Cover> Covers { get; }
    [SerializeField] private List<Cover> _covers = new();

    private AssetsLoader _assetsLoader;

    public void Init(LevelsArguments args)
    {
        _assetsLoader = args.AssetsLoader;
    }

    public void Dispose()
    {
        _assetsLoader.UnloadAsset();
    }
}