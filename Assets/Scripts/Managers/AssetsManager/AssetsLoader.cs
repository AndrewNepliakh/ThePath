using System;
using Zenject;
using UnityEngine;
using System.Threading.Tasks;
using Object = UnityEngine.Object;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Managers
{
    public class AssetsLoader : IAssetsLoader
    {
        private GameObject _cachedObject;
        private AsyncOperationHandle<GameObject> _handle;

        public async Task<T> InstantiateAsset<T>(Transform parent = null, bool instantiateInWorldSpace = false)
        {
            _handle = Addressables.InstantiateAsync(typeof(T).ToString(), parent, instantiateInWorldSpace);
            _cachedObject = await _handle.Task;
            return TryGetComponent<T>();;
        }
        
        public async Task<T> InstantiateAssetWithDI<T>(string ID, DiContainer diContainer, Transform parent = null)
        {
            _handle = Addressables.LoadAssetAsync<GameObject>(ID);
            var prefab = await _handle.Task;
            _cachedObject = diContainer.InstantiatePrefab(prefab, parent);
            if(parent != null) _cachedObject.transform.SetParent(parent, false);
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
            if (_cachedObject != null)
            {
                Object.Destroy(_cachedObject);
                Addressables.Release(_handle);
            }
            
            _cachedObject = null;
        }
    }
}