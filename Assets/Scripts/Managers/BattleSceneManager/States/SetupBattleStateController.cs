using System.Threading.Tasks;
using Controllers;
using Managers;
using Zenject;

public class SetupBattleStateController : IBattleStateController
{
    [Inject] private BattleSceneManager _battleSceneManager;
    [Inject] private SetupBattleState _state;
    [Inject] private ILevelManager _levelManager;
    [Inject] private IGameManager _gameManager;
    [Inject] private IUIManager _uiManager;

    public async Task Init()
    {
        _state.OnStateComplete += OnStateComplete;
        
        _battleSceneManager.SetLevel(await _levelManager.InstantiateLevel<Level_1>(new LevelsArguments
            {UnitsData = _gameManager.UnitsData}));

        var args = new SetupBattleWindowArguments
        {
            BattleSceneManager = _battleSceneManager,
            SetupBattleState = _state
        };
        
        await _uiManager.ShowWindow<SetupBattleWindow>(args);
    }

    private void OnStateComplete()
    {
        _state.OnStateComplete -= OnStateComplete;
    }
}