using Managers;
using UnityEngine;
using Zenject;

public class BattleSceneController : MonoBehaviour
{
   [Inject] private IUIManager _uiManager; 
   
   [SerializeField] private Canvas _mainCanvas;

   private ChooseActionWindow _actionWindow;

   private async void Awake()
   {
      _uiManager.Init(_mainCanvas);
      _actionWindow = await _uiManager.ShowWindow<ChooseActionWindow>();
   }
   
}
