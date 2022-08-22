using System;
using System.Threading.Tasks;
using Zenject;

namespace Managers
{
    public class UnitsManager : IUnitsManager
    {
        [Inject] private DiContainer _diContainer;
        
        private Unit[] _playerUnits;
        private Unit[] _opponentUnits;

        private UnitsData _unitsData;
        private int _allUnits;

        public void Init(UnitsData unitsData)
        {
            _unitsData = unitsData;
            _playerUnits = new Unit[unitsData.playerUnits];
            _opponentUnits = new Unit[unitsData.opponentUnits];
            _allUnits = _playerUnits.Length + _opponentUnits.Length;
        }

        public async Task<UnitsList> InstantiateUnits()
        {
            for (var i = 0; i < _playerUnits.Length; i++)
            {
                var loader = new AssetsLoader();
                var unit = await loader.InstantiateAssetWithDI<Unit>(typeof(Unit).ToString(), _diContainer);
                _playerUnits[i] = unit;

                var args = new UnitArguments { AssetsLoader = loader, Speed = 1.0f, UnitSide = UnitSide.Player};
                
                _playerUnits[i].Init(args);
            }
            
            for (var i = 0; i < _opponentUnits.Length; i++)
            {
                var loader = new AssetsLoader();
                var unit = await loader.InstantiateAssetWithDI<Unit>(typeof(Unit).ToString(), _diContainer);
                _opponentUnits[i] = unit;
                
                var args = new UnitArguments { AssetsLoader = loader, Speed = 1.0f, UnitSide = UnitSide.Opponent};
                
                _opponentUnits[i].Init(args);
            }

            return new UnitsList {playerUnits = _playerUnits, opponentUnits = _opponentUnits};
        }
    }

    [Serializable]
    public class UnitsList
    {
        public Unit[] playerUnits;
        public Unit[] opponentUnits;
    }
}