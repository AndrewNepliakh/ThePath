using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Managers;
using UnityEngine;
using Zenject;

public abstract class Level : MonoBehaviour, ILevel
{
    [Inject] protected IUnitsManager _unitsManager;

    public List<Cover> Covers => _covers;
    public UnitsList Units => _units;
    
    [SerializeField] protected List<Cover> _covers = new();
    protected UnitsList _units;

    private AssetsLoader _assetsLoader;

    public async Task Init(LevelsArguments args)
    {
        _assetsLoader = args.AssetsLoader;
        _unitsManager.Init(args.UnitsData);
        _units = await _unitsManager.InstantiateUnits();
    }

    public void Dispose()
    {
        _assetsLoader.UnloadAsset();
    }
}