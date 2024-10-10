using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Managers
{
    public class AssetsLoader : IAssetsLoader
    {
        private GameObject _cachedObject;

        public async Task<T> InstantiateAsset<T>(Transform parent = null, bool instantiateInWorldSpace = false)
        {
            var handle = Addressables.InstantiateAsync(typeof(T).ToString(), parent, instantiateInWorldSpace);
            _cachedObject = await handle.Task;
            return TryGetComponent<T>();;
        }
        
        public async Task<T> InstantiateAssetWithDI<T>(string ID, DiContainer diContainer, Transform parent = null)
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(ID);
            var prefab = await handle.Task;
            _cachedObject = diContainer.InstantiatePrefab(prefab);
            if(parent != null) _cachedObject.transform.SetParent(parent);
            return TryGetComponent<T>();
        }

        private T TryGetComponent<T>()
        {
            if (_cachedObject.TryGetComponent(out T component) == false)
            {
                throw new NullReferenceException(
                    $"Object of type {typeof(T)} is null on attempt to load it from addressables");
            }

            return component;
        }

        public void UnloadAsset()
        {
            if (_cachedObject == null) return;

            _cachedObject.SetActive(false);
            Addressables.ReleaseInstance(_cachedObject);
            _cachedObject = null;
        }
    }
}