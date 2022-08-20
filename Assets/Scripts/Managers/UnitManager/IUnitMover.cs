using Managers;
using UnityEngine;

public interface IUnitMover
{
    void Init(UnitMoverArguments args);
    void Move(Vector3 coordinates);
}