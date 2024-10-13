using System;
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
        private int _allUnits;

        public void Init(UnitsData unitsData)
        {
            _unitsData = unitsData;
            _playerUnits = new Unit[_unitsData.playerUnits];
            _opponentUnits = new Unit[_unitsData.opponentUnits];
            _allUnits = _playerUnits.Length + _opponentUnits.Length;
        }

        public async Task<UnitsList> InstantiateUnits()
        {
            for (var i = 0; i < _playerUnits.Length; i++)
            {
                var loader = new AssetsLoader();
                var unit = await loader.InstantiateAssetWithDI<Unit>(typeof(Unit).ToString(), _diContainer);
                unit.SetStartPosition(GetPlayerUnitsStartPosition(i));
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

    [Serializable]
    public class UnitsList
    {
        public Unit[] playerUnits;
        public Unit[] opponentUnits;
    }
}