using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResultWindow : Window
    {
        public event Action OnContinueClicked;

        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private Button _continueButton;

        public override void Show(UIViewArguments arguments)
        {
            base.Show(arguments);
            _titleText.text = ((ResultWindowArguments)arguments).Message;
            _continueButton.onClick.AddListener(OnContinueButtonClicked);
        }

        private void OnContinueButtonClicked()
        {
            OnContinueClicked?.Invoke();
        }

        public override void Hide(UIViewArguments arguments = null)
        {
            base.Hide(arguments);
            _continueButton.onClick.RemoveListener(OnContinueButtonClicked);
        }
    }
}