using UI;
using Zenject;
using Managers;
using Controllers;
using System.Threading.Tasks;

public class SetupBattleStateController : IBattleStateController
{
    [Inject] private SetupBattleState _state;
    [Inject] private ISelectorUnitManager _selectorUnitManager;
    [Inject] private ILevelManager _levelManager;
    [Inject] private IUnitsManager _unitsManager;
    [Inject] private IUIManager _uiManager;

    public async Task Init()
    {
        _state.OnStateComplete += OnStateComplete;
        
        await InitLevel();
        await InitUnits();
        ShowSetupBattleWindow();
        _selectorUnitManager.RunPlayerUnitsSelectionQueue();
    }
    
    private async Task InitLevel() => 
        await _levelManager.InstantiateLevel<Level_1>(new LevelsArguments());

    private async Task InitUnits()
    {
        await _unitsManager.InstantiateUnits();
    }

    private async void ShowSetupBattleWindow()
    {
        await _uiManager.ShowWindowWithDI<SetupBattleWindow>();
    }

    private void OnStateComplete()
    {
        _state.OnStateComplete -= OnStateComplete;
    }
}