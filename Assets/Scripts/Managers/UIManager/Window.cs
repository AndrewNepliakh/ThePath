using System;
using UnityEngine;

namespace Managers
{
    public abstract class Window : MonoBehaviour, IUIView
    {
        protected IUIManager UIManager;
        public AssetsLoader AssetsLoader { get; set; }

        public virtual void Show(UIViewArguments arguments)
        {
            if (arguments != null)
            {
                AssetsLoader = arguments.AssetsLoader;
                UIManager = arguments.UIManager;
            }
            
            gameObject.SetActive(true);
        }

        public virtual void Hide(UIViewArguments arguments)
        {
            gameObject.SetActive(false);
        }
    }
}