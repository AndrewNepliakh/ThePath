using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Managers
{
    public class UIManager : IUIManager
    {
        [Inject] private IUIManager _uiManager;
        
        private Window _currentWindow;
        private Canvas _mainCanvas;

        public void Init(Canvas mainCanvas)
        {
            _mainCanvas = mainCanvas;
        }

        public async Task<T> ShowWindow<T>(UIViewArguments args = null)
            where T : Window
        {
            var loader = new AssetsLoader();
            var newWindow = await loader.LoadAsset<T>(_mainCanvas.transform);

            if (_currentWindow != null) _currentWindow.Hide();
            _currentWindow = newWindow;

            if (args == null) args = new UIViewArguments {AssetsLoader = loader};
            else args.AssetsLoader = loader;

            _currentWindow.Show(args);

            return (T) _currentWindow;
        }

        public void HideWindow(UIViewArguments args = null)
        {
            _currentWindow.Hide(args);
        }
    }
}