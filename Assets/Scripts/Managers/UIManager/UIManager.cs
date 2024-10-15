using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Managers;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UIManager : IUIManager
    {
        [Inject] private IUIManager _uiManager;
        [Inject] private DiContainer _diContainer;
        
        private Window _currentWindow;
        private Window _currentHUDWindow;
        private Canvas _mainCanvas;

        private Dictionary<Type, IUIView> _viewsPool = new();
        private Dictionary<Type, IUIView> _HUDPool = new();

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
        
        public async Task<T> ShowWindowWithDI<T>(UIViewArguments args = null)
            where T : Window
        {
            if (_currentWindow != null) _currentWindow.Hide(null);
            
            if (!_viewsPool.ContainsKey(typeof(T)))
            {
                var loader = new AssetsLoader();
                var newWindow = await loader.InstantiateAssetWithDI<T>(typeof(T).ToString(), _diContainer, _mainCanvas.transform);
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
        
        public async Task<T> ShowHUDWindowWithDI<T>(UIViewArguments args = null) where T : Window
        {
            if (_currentHUDWindow != null) _currentHUDWindow.Hide(null);
            
            if (!_HUDPool.ContainsKey(typeof(T)))
            {
                var loader = new AssetsLoader();
                var newWindow = await loader.InstantiateAssetWithDI<T>(typeof(T).ToString(), _diContainer, _mainCanvas.transform);
                _currentHUDWindow = newWindow;
                _HUDPool.Add(typeof(T), _currentHUDWindow);
                
                if (args == null) args = new UIViewArguments {AssetsLoader = loader};
                else args.AssetsLoader = loader;

                _currentHUDWindow.Show(args);
            }
            else
            {
                if (_HUDPool.TryGetValue(typeof(T), out var uiView))
                {
                    _currentHUDWindow = uiView as Window;
                    _currentHUDWindow.Show(args);
                }
                else
                {
                    throw new NullReferenceException("UIManager's pool doesn't contain view of this type");
                }
            }
            
            return (T) _currentHUDWindow;
        }

        public void HideWindow(UIViewArguments args)
        {
            _currentWindow.Hide(args);
        }
    }
}