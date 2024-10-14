using Zenject;
using UnityEngine;
using System.Threading.Tasks;

namespace Managers
{
    public class UnitsManager : IUnitsManager
    {
        [Inject] private DiContainer _diContainer;
        
        private Unit[] _playerUnits;
        private Unit[] _opponentUnits;

        private UnitsData _unitsData;

        public Unit[] PlayerUnits => _playerUnits;
        public Unit[] OpponentUnits => _opponentUnits;

        public void Init(UnitsData unitsData) => _unitsData = unitsData;
        
        public async Task InstantiateUnits()
        {
            RemoveAllUnits();
            await InitPlayerUnits();
            await InitOpponentUnits();
        }

        private void RemoveAllUnits()
        {
            if (_playerUnits is null || _opponentUnits is null)
            {
                _playerUnits = new Unit[_unitsData.playerUnits];
                _opponentUnits = new Unit[_unitsData.opponentUnits];
                
                return;
            }

            foreach (var unit in _playerUnits)  
                unit.Dispose();
            
            foreach (var unit in _opponentUnits)  
                unit.Dispose();
            
            _playerUnits = new Unit[_unitsData.playerUnits];
            _opponentUnits = new Unit[_unitsData.opponentUnits];
        }

        private async Task InitPlayerUnits()
        {
            for (var i = 0; i < _playerUnits.Length; i++)
            {
                var loader = new AssetsLoader();
                var unit = await loader.InstantiateAssetWithDI<Unit>(typeof(Unit).ToString(), _diContainer);
                unit.SetStartPosition(GetPlayerUnitsStartPosition(i));
                _playerUnits[i] = unit;

                var args = new UnitArguments
                {
                    AssetsLoader = loader, 
                    Speed = 1.0f, 
                    UnitSide = UnitSide.Player,
                    Index = (i + 1).ToString()
                };
                
                _playerUnits[i].Init(args);
            }
        }
        
        private async Task InitOpponentUnits()
        {
            for (var i = 0; i < _opponentUnits.Length; i++)
            {
                var loader = new AssetsLoader();
                var unit = await loader.InstantiateAssetWithDI<Unit>(typeof(Unit).ToString(), _diContainer);
                _opponentUnits[i] = unit;
                
                var args = new UnitArguments
                {
                    AssetsLoader = loader, 
                    Speed = 1.0f, 
                    UnitSide = UnitSide.Opponent,
                    Index = (i + 1).ToString()
                };
                
                _opponentUnits[i].Init(args);
            }
        }

        private Vector3 GetPlayerUnitsStartPosition(int index)
        {
            var range = GetMiddleRange(_playerUnits.Length);
            return Vector3.right * range[index];
        }

        private int[] GetMiddleRange(int range)
        {
            var initialRange = new int[range];

            for (var i = 0; i < range; i++)
                initialRange[i] = i + 1;

            var middleValue = initialRange[range / 2];
            var middleRange = new int[range];

            if (range % 2 == 0)
            {
                for (var i = 0; i < range; i++)
                    middleRange[i] = ((initialRange[i] - middleValue) * 2) + 1;
            }
            else
            {
                for (var i = 0; i < range; i++)
                    middleRange[i] = (initialRange[i] - middleValue) * 2;
            }

            return middleRange;
        }
    }
}