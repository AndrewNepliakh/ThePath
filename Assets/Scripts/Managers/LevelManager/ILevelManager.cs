using System.Threading.Tasks;

namespace Managers
{
    public interface ILevelManager
    {
        public Level CurrentLevel { get; }
        Task InstantiateLevel<T>(LevelsArguments args = null) where T : Level;
    }
}