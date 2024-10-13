using Managers;

namespace UI
{
    public interface IUIView
    {
        AssetsLoader AssetsLoader { get; set; }
        void Show(UIViewArguments arguments);
        void Hide(UIViewArguments arguments);
    }
}