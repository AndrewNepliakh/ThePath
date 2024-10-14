using Controllers;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour, IUnit
{
    private const float DEFAULT_OPPONENT_Z_POSITION = 29.0f;

    [SerializeField] private Animator _animator;
    [SerializeField] private UnitMover _mover;

    [Space(10)] 
    [SerializeField] private GameObject _choceCanvas;
    
    [SerializeField] private TMP_Text _choceText;
    [SerializeField] private TMP_Text _nameText;
    
    [SerializeField] private Image _choceTextImage;
    
    private AssetsLoader _assetsLoader;
    
    private bool _isSetCoverPosition;
    
    private UnitSide _unitSide;
    private ActionType _actionChoice;
    
    public UnitSide UnitSide => _unitSide;

    public ActionType ActionChoice => _actionChoice;

    public bool IsSetCoverPosition => _isSetCoverPosition;
    
    public void Init(UnitArguments args)
    {
        _nameText.text = args.Index;
        
        _assetsLoader = args.AssetsLoader;
        _unitSide = args.UnitSide;
        
        _choceCanvas.SetActive(false);
        
        _mover.Init(new UnitMoverArguments {Speed = args.Speed});

        if (_unitSide == UnitSide.Opponent)
            transform.position = new Vector3(transform.position.x, transform.position.y, DEFAULT_OPPONENT_Z_POSITION);
    }
    
    public void SetStartPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetCoverPosition(Vector3 position)
    {
        transform.position = position;
        _isSetCoverPosition = true;
    }
    
    public void SetActionChoice(ActionType actionType)
    {
        _actionChoice = actionType;
        _choceCanvas.SetActive(true);

        switch (actionType)
        {
            case ActionType.Attack:
                SetChoiceLabel("Attack", new Color(1.0f, 0.5f, 0.5f));
                break;
            case ActionType.Move:
                SetChoiceLabel("Move", new Color(0.5f, 0.8f, 1.0f));
                break;
            case ActionType.Cover:
                SetChoiceLabel("Cover", new Color(1.0f, 1.0f, 0.7f));
                break;
        }
    }

    private void SetChoiceLabel(string text, Color color)
    {
        _choceText.text = text;
        _choceTextImage.color = color;
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