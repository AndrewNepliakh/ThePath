using Managers;
using UnityEngine;
using System.Collections.Generic;

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