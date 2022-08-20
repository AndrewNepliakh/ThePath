using System.Threading.Tasks;

namespace Managers
{
    public interface ILevelManager
    {
        Task<T> InstantiateLevel<T>(LevelsArguments args = null) where T : Level;
    }
}