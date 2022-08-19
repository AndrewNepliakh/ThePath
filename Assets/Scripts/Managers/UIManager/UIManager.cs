using System;
namespace Managers
{
    public class UIManager : IUIManager
    {
        private Window _currentWindow;
        
        public T ShowWindow<T>(UIViewArguments args = null)
            where T : Window
        {
            var loader = new AssetsLoader();
            var newWindow = loader.LoadAsset<T>();

            _currentWindow.Hide();
            _currentWindow = newWindow.Result;

            if (args == null) args = new UIViewArguments { AssetsLoader = loader};
            else  args.AssetsLoader = loader;

            _currentWindow.Show(args);

            return (T) _currentWindow;
        }
    }
}