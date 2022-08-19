using System.Threading.Tasks;

namespace Managers
{
    public interface IAssetsLoader
    {
         Task<T> LoadAsset<T>();
         void UnloadAsset();
    }
}