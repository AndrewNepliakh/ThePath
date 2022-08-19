using System;
using UnityEngine;

namespace Managers
{
    public abstract class Window : MonoBehaviour, IUIView
    {
        public AssetsLoader AssetsLoader { get; set; }

        public virtual void Show(UIViewArguments arguments)
        {
            AssetsLoader = arguments.AssetsLoader;
        }

        public virtual void Hide(UIViewArguments arguments = null)
        {
            AssetsLoader.UnloadAsset();
        }
    }
}