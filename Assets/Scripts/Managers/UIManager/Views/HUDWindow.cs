using TMPro;
using Zenject;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HUDWindow : Window
    {
        [Inject] private ISelectorUnitManager _selectorUnitManager;
        
        [SerializeField] private Image _avatar;
        [SerializeField] private TMP_Text _nameText;

        public override void Show(UIViewArguments arguments)
        {
            base.Show(arguments);

            _selectorUnitManager.OnSelectedUnitChanged += OnSelectedUnitChange;
        }

        private void OnSelectedUnitChange(Unit unit)
        {
            _avatar.sprite = unit.Avatar;
            _nameText.text = unit.Name;
        }
    }
}