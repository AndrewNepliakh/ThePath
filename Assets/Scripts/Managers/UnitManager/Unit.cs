using Managers;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Unit : MonoBehaviour, IUnit
{
    public UnitSide UnitSide => _unitSide;

    [SerializeField] private Animator _animator;
    [SerializeField] private UnitMover _mover; 

    private UnitSide _unitSide;
    private AssetsLoader _assetsLoader;

    public void Init(UnitArguments args)
    {
        _assetsLoader = args.AssetsLoader;
        _mover.Init(new UnitMoverArguments{Speed = args.Speed});
    }

    public void Attack()
    {
        
    }
    
    public void Move(Vector3 coordinates)
    {
        
    }
    
    public void Cover()
    {
        
    }

    public void Dispose()
    {
        _assetsLoader.UnloadAsset();
    }
}

public enum UnitSide
{
    Player,
    Opponent
}