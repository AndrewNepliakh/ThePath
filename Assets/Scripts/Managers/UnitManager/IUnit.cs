using System.Numerics;

namespace Managers
{
    public interface IUnit
    {
        public UnitSide UnitSide { get; }
        public void Init(UnitArguments args);
        
        void Move(Vector3 coordinates);
        public void Dispose();
    }
}