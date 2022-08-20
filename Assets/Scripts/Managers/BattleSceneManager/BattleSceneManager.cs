using Managers;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class BattleSceneManager : MonoBehaviour
    {
        [Inject] private ILevelManager _levelManager;
        [Inject] private IGameManager _gameManager;
        [Inject] private IUIManager _uiManager;
 
        [SerializeField] private Canvas _mainCanvas;

        private IAIChoiceManager _iaiChoiceManager;
        private IChoiceResulter _choiceResulter;

        private ChooseActionWindow _actionWindow;
        private ResultWindow _resultWindow;
        
        private Level _level;

        private async void Awake()
        {
            _iaiChoiceManager = new IaiChoiceManager(_gameManager.UnitsData.opponentUnits);
            _choiceResulter = new ChoiceResulter();

            _uiManager.Init(_mainCanvas);

            _actionWindow = await _uiManager.ShowWindow<ChooseActionWindow>();
            _actionWindow.OnChooseAction += ProceedAction;

            InitLevel();
        }

        private async void InitLevel()
        {
            _level = await _levelManager.InstantiateLevel<Level_1>(new LevelsArguments {UnitsData = _gameManager.UnitsData});
        }

        private async void ProceedAction(ActionChoice choice)
        {
            var aiChoices = _iaiChoiceManager.GetChoices();
            var result = _choiceResulter.GetResult(choice.ActionChoices, aiChoices.ActionChoices);

            var args = new ResultWindowArguments
            {
                Message = result + " Opponent choose " + aiChoices.ActionChoices[0] + 
                          " , You choose " + choice.ActionChoices[0]
            };
            
            _resultWindow = await _uiManager.ShowWindow<ResultWindow>(args);
            _resultWindow.OnContinueClicked += Continue;
        }

        private async void Continue()
        {
            await _uiManager.ShowWindow<ChooseActionWindow>();
        }
    }
}