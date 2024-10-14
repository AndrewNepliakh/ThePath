using Zenject;
using System.Threading.Tasks;

namespace Managers
{
    public class LevelManager : ILevelManager
    {
        [Inject] private DiContainer _diContainer;
        
        private Level _currentLevel;
        
        public Level CurrentLevel => _currentLevel;

        public async Task InstantiateLevel<T>(LevelsArguments args) where T : Level
        {
            var loader = new AssetsLoader();

            _currentLevel?.Dispose();

            _currentLevel = await loader.InstantiateAssetWithDI<T>(typeof(T).ToString(), _diContainer);

            if (args == null) args = new LevelsArguments {AssetsLoader = loader};
            else args.AssetsLoader = loader;
            
            _currentLevel.Init(args);
        }
    }
}