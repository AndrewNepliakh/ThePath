using Controllers;
using Managers;
using UnityEngine;

public class Unit : MonoBehaviour, IUnit
{
    private const float DEFAULT_OPPONENT_Z_POSITION = 29.0f;

    [SerializeField] private Animator _animator;
    [SerializeField] private UnitMover _mover;
    
    private UnitSide _unitSide;
    private AssetsLoader _assetsLoader;
    
    public UnitSide UnitSide => _unitSide;
    
    public ActionType ActionChoice { get; set; }

    public void Init(UnitArguments args)
    {
        _assetsLoader = args.AssetsLoader;
        _unitSide = args.UnitSide;
        
        _mover.Init(new UnitMoverArguments {Speed = args.Speed});

        if (_unitSide == UnitSide.Opponent)
            transform.position = new Vector3(transform.position.x, transform.position.y, DEFAULT_OPPONENT_Z_POSITION);
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