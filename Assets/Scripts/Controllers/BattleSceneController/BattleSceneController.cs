using System;
using Managers;
using UnityEngine;
using Zenject;

namespace Controllers
{
    public class BattleSceneController : MonoBehaviour
    {
        [Inject] private IUIManager _uiManager;
        [Inject] private IGameManager _gameManager;

        [SerializeField] private Canvas _mainCanvas;

        private IAIChoiceController _aiChoiceController;
        private IChoiceResulter _choiceResulter;

        private ChooseActionWindow _actionWindow;
        private ResultWindow _resultWindow;

        private AssetsLoader _levelLoader;
        private LevelController _level;
        
        [Inject] private DiContainer _diContainer;

        private async void Awake()
        {
            _aiChoiceController = new AIChoiceController(_gameManager.AIAmount);
            _choiceResulter = new ChoiceResulter();

            _uiManager.Init(_mainCanvas);

            _actionWindow = await _uiManager.ShowWindow<ChooseActionWindow>();
            _actionWindow.OnChooseAction += ProceedAction;

            InitLevel();
        }

        private async void InitLevel()
        {
            _levelLoader = new AssetsLoader();
            _level = await _levelLoader.InstantiateAssetWithDI<LevelController>(_gameManager.LevelID);
        }

        private async void ProceedAction(ActionChoice choice)
        {
            var aiChoices = _aiChoiceController.GetChoices();
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