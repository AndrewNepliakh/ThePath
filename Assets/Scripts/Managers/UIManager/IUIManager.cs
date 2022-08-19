using System.Threading.Tasks;
using UnityEngine;

namespace Managers
{
    public interface IUIManager
    {
        void Init(Canvas mainCanvas);

        Task<T> ShowWindow<T>(UIViewArguments args = null) where T : Window;

        void HideWindow(UIViewArguments args = null);
    }
}