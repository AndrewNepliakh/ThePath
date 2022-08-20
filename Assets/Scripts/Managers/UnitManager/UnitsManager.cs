using System;
using System.Threading.Tasks;
using Zenject;

namespace Managers
{
    public class UnitsManager : IUnitsManager
    {
        [Inject] private DiContainer _diContainer;
        
        private IUnit[] _playerUnits;
        private IUnit[] _opponentUnits;

        private UnitsData _unitsData;
        private int _allUnits;

        public void Init(UnitsData unitsData)
        {
            _unitsData = unitsData;
            _playerUnits = new IUnit[unitsData.playerUnits];
            _opponentUnits = new IUnit[unitsData.opponentUnits];
            _allUnits = _playerUnits.Length + _opponentUnits.Length;
        }

        public async Task<UnitsList> InstantiateUnits()
        {
            for (var i = 0; i < _playerUnits.Length; i++)
            {
                var loader = new AssetsLoader();
                var unit = await loader.InstantiateAssetWithDI<Unit>(typeof(Unit).ToString(), _diContainer);
                _playerUnits[i] = unit;

                var args = new UnitArguments { AssetsLoader = loader, Speed = 1.0f};
                
                _playerUnits[i].Init(args);
            }
            
            for (var i = 0; i < _opponentUnits.Length; i++)
            {
                var loader = new AssetsLoader();
                var unit = await loader.InstantiateAssetWithDI<Unit>(typeof(Unit).ToString(), _diContainer);
                _opponentUnits[i] = unit;
                
                var args = new UnitArguments { AssetsLoader = loader, Speed = 1.0f};
                
                _opponentUnits[i].Init(args);
            }

            return new UnitsList {playerUnits = _playerUnits, opponentUnits = _opponentUnits};
        }
    }

    [Serializable]
    public class UnitsList
    {
        public IUnit[] playerUnits;
        public IUnit[] opponentUnits;
    }
}