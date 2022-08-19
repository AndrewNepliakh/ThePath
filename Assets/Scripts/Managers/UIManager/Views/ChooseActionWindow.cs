using System;
using Controllers;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class ChooseActionWindow : Window
{
    public event Action<ActionChoice> OnChooseAction;

    [SerializeField] private Button _attackButton;
    [SerializeField] private Button _moveButton;
    [SerializeField] private Button _coverButton;

    public override void Show(UIViewArguments arguments = null)
    {
        base.Show(arguments);
        _attackButton.onClick.AddListener(OnAttackButtonClicked);
        _moveButton.onClick.AddListener(OnMoveButtonClicked);
        _coverButton.onClick.AddListener(OnCoverButtonClicked);
    }

    private void OnAttackButtonClicked()
    {
        var attackChoice = new ActionChoice {ActionChoices = new []{ActionType.Attack}};
        OnChooseAction?.Invoke(attackChoice);
    }

    private void OnMoveButtonClicked()
    {
        var moveChoice = new ActionChoice {ActionChoices = new []{ActionType.Move}};
        OnChooseAction?.Invoke(moveChoice);
    }

    private void OnCoverButtonClicked()
    {
        var coverChoice = new ActionChoice {ActionChoices = new []{ActionType.Cover}};
        OnChooseAction?.Invoke(coverChoice);
    }

    public override void Hide(UIViewArguments arguments = null)
    {
        base.Hide(arguments);
        _attackButton.onClick.RemoveListener(OnAttackButtonClicked);
        _moveButton.onClick.RemoveListener(OnMoveButtonClicked);
        _coverButton.onClick.RemoveListener(OnCoverButtonClicked);
    }
}