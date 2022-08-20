using System;
using System.Collections.Generic;
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

        private Dictionary<Type, IUIView> _viewsPool = new();

        public void Init(Canvas mainCanvas)
        {
            _mainCanvas = mainCanvas;
        }

        public async Task<T> ShowWindow<T>(UIViewArguments args)
            where T : Window
        {
            if (_currentWindow != null) _currentWindow.Hide(null);
            
            if (!_viewsPool.ContainsKey(typeof(T)))
            {
                var loader = new AssetsLoader();
                var newWindow = await loader.InstantiateAsset<T>(_mainCanvas.transform);
                _currentWindow = newWindow;
                _viewsPool.Add(typeof(T), _currentWindow);
                
                if (args == null) args = new UIViewArguments {AssetsLoader = loader};
                else args.AssetsLoader = loader;

                _currentWindow.Show(args);
            }
            else
            {
                if (_viewsPool.TryGetValue(typeof(T), out var uiView))
                {
                    _currentWindow = uiView as Window;
                    _currentWindow.Show(args);
                }
                else
                {
                    throw new NullReferenceException("UIManager's pool doesn't contain view of this type");
                }
            }
            
            return (T) _currentWindow;
        }

        public void HideWindow(UIViewArguments args)
        {
            _currentWindow.Hide(args);
        }
    }
}