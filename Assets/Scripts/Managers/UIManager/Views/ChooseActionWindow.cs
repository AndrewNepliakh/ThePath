using Managers;
using UnityEngine;
using UnityEngine.UI;

public class ChooseActionWindow : Window
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _attackButton;
    [SerializeField] private Button _moveButton;
    [SerializeField] private Button _coverButton;
    
    public override void Show(UIViewArguments arguments)
    {
        base.Show(arguments);
        
        _closeButton.onClick.AddListener(OnCloseButtonClicked);
    }
    
    private void OnCloseButtonClicked()
    {
        Hide();
    }

    public override void Hide(UIViewArguments arguments = null)
    {
        base.Hide(arguments);
        
        _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
    }
}