using Managers;
using UnityEngine;

namespace UI
{
    public abstract class Window : MonoBehaviour, IUIView
    {
        public AssetsLoader AssetsLoader { get; set; }
        
        public virtual void Show(UIViewArguments arguments)
        {
            if (arguments != null)
            {
                AssetsLoader = arguments.AssetsLoader;
            }
            
            gameObject.SetActive(true);
        }

        public virtual void Hide(UIViewArguments arguments)
        {
            gameObject.SetActive(false);
        }
    }
}