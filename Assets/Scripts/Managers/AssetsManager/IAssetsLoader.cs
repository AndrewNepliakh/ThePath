﻿using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Managers
{
    public interface IAssetsLoader
    {
         Task<T> InstantiateAsset<T>(Transform parent, bool instantiateInWorldSpace = false);
         Task<T> InstantiateAssetWithDI<T>(string ID, DiContainer diContainer, Transform parent = null);
         void UnloadAsset();
    }
}