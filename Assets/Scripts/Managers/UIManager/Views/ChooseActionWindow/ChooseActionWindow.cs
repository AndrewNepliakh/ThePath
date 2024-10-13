using System;
using Managers;
using UnityEngine;
using Controllers;
using System.Linq;
using UnityEngine.UI;
using System.Collections.Generic;

namespace UI
{
    public class ChooseActionWindow : Window
    {
        public event Action<ActionType> OnChooseAction;
        public event Action OnConfirmActionPhase;
    
        [SerializeField] private Button _attackButton;
        [SerializeField] private Button _moveButton;
        [SerializeField] private Button _coverButton;
        [SerializeField] private Button _confirmButton;
        
        [Space(10)]
        [SerializeField] private List<ChooseActionWindowButtonsContainer> _buttonsContainers = new ();
    
        private Dictionary<ActionButtonContainerType, ChooseActionWindowButtonsContainer>
            _dictionaryButtonsContainers = new ();
    
        public override void Show(UIViewArguments arguments = null)
        {
            base.Show(arguments);
            
            _dictionaryButtonsContainers = _buttonsContainers.ToDictionary(c => c.Type, c => c.Value);
            SwitchButtonContainers(ActionButtonContainerType.ChooseActionPhase);
            
            _attackButton.onClick.AddListener(OnAttackButtonClicked);
            _moveButton.onClick.AddListener(OnMoveButtonClicked);
            _coverButton.onClick.AddListener(OnCoverButtonClicked);
            _confirmButton.onClick.AddListener(OnConfirmActionButtonClicked);
        }
    
        public void SwitchButtonContainers(ActionButtonContainerType type)
        {
            foreach (var buttonContainer in _buttonsContainers)
                buttonContainer.SetActive(false);
            
            switch (type)
            {
                case ActionButtonContainerType.ChooseActionPhase:
                    _dictionaryButtonsContainers[ActionButtonContainerType.ChooseActionPhase].SetActive(true);
                    break;
                case ActionButtonContainerType.EndActionPhase:
                    _dictionaryButtonsContainers[ActionButtonContainerType.EndActionPhase].SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    
        private void OnAttackButtonClicked()
        {
            OnChooseAction?.Invoke(ActionType.Attack);
        }
    
        private void OnMoveButtonClicked()
        {
            OnChooseAction?.Invoke(ActionType.Move);
        }
    
        private void OnCoverButtonClicked()
        {
            OnChooseAction?.Invoke(ActionType.Cover);
        }
        
        private void OnConfirmActionButtonClicked()
        {
            OnConfirmActionPhase?.Invoke();
        }
    
        public override void Hide(UIViewArguments arguments = null)
        {
            base.Hide(arguments);
            _attackButton.onClick.RemoveListener(OnAttackButtonClicked);
            _moveButton.onClick.RemoveListener(OnMoveButtonClicked);
            _coverButton.onClick.RemoveListener(OnCoverButtonClicked);
            _confirmButton.onClick.RemoveListener(OnConfirmActionButtonClicked);
        }
    }
}
