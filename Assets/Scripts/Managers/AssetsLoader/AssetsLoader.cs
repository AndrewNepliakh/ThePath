using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Managers
{
    public class AssetsLoader : IAssetsLoader
    {
        private GameObject _cachedObject;

        public async Task<T> LoadAsset<T>(Transform parent = null)
        {
            var handle = Addressables.InstantiateAsync(typeof(T).ToString(), parent);
            _cachedObject = await handle.Task;

            if (_cachedObject.TryGetComponent(out T asset) == false)
            {
                throw new NullReferenceException(
                    $"Object of type {typeof(T)} is null on attempt to load it from addressables");
            }

            return asset;
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