using System.Threading.Tasks;
using UnityEngine;

namespace Managers
{
    public interface IAssetsLoader
    {
         Task<T> LoadAsset<T>(Transform parent);
         void UnloadAsset();
    }
}