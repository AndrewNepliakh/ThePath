using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Managers;
using UnityEngine;
using Zenject;

public abstract class Level : MonoBehaviour, ILevel
{
    [SerializeField] protected List<Cover> _covers = new();
    
    public List<Cover> Covers => _covers;

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