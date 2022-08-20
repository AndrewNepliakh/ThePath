using System.Threading.Tasks;
using Zenject;

namespace Managers
{
    public class LevelManager : ILevelManager
    {
        [Inject] private DiContainer _diContainer;

        public async Task<T> InstantiateLevel<T>(LevelsArguments args) where T : Level
        {
            var loader = new AssetsLoader();
            var level = await loader.InstantiateAssetWithDI<T>(typeof(T).ToString(), _diContainer);

            if (args == null) args = new LevelsArguments {AssetsLoader = loader};
            else args.AssetsLoader = loader;
            
            level.Init(args);
            
            return level;
        }
    }
}