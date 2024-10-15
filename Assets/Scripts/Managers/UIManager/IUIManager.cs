using System.Threading.Tasks;
using UnityEngine;

namespace UI
{
    public interface IUIManager
    {
        void Init(Canvas mainCanvas);

        Task<T> ShowWindow<T>(UIViewArguments args = null) where T : Window;

        Task<T> ShowWindowWithDI<T>(UIViewArguments args = null)
            where T : Window;
        
        Task<T> ShowHUDWindowWithDI<T>(UIViewArguments args = null)
            where T : Window;

        void HideWindow(UIViewArguments args = null);
    }
}