using System.Threading.Tasks;
using UnityEngine;

namespace Managers
{
    public interface IAssetsLoader
    {
         Task<T> InstantiateAsset<T>(Transform parent);
         void UnloadAsset();
    }
}