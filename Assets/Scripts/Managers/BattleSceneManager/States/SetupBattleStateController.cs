using System.Threading.Tasks;
using Controllers;
using Managers;
using UI;
using Zenject;

public class SetupBattleStateController : IBattleStateController
{
    [Inject] private SetupBattleState _state;
    [Inject] private ILevelManager _levelManager;
    [Inject] private IUnitsManager _unitsManager;
    [Inject] private IGameManager _gameManager;
    [Inject] private IUIManager _uiManager;

    public async Task Init()
    {
        _state.OnStateComplete += OnStateComplete;
        
        await InitLevel();
        await InitUnits();
        ShowSetupBattleWindow();
    }
    
    private async Task InitLevel() => 
        await _levelManager.InstantiateLevel<Level_1>(new LevelsArguments {UnitsData = _gameManager.UnitsData});

    private async Task InitUnits()
    {
        _unitsManager.Init(_gameManager.UnitsData);
        await _unitsManager.InstantiateUnits();
    }

    private async void ShowSetupBattleWindow()
    {
        var args = new SetupBattleWindowArguments
        {
            UnitsManager = _unitsManager,
            LevelManager = _levelManager,
            SetupBattleState = _state
        };
        
        await _uiManager.ShowWindow<SetupBattleWindow>(args);
    }

    private void OnStateComplete()
    {
        _state.OnStateComplete -= OnStateComplete;
    }
}