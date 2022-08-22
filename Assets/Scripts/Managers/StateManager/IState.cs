using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

namespace Managers
{
    public interface IState<T> : IDisposable where T : Enum 
    {
        T State { get; }
        void Enter(ChangeStateData changeStateData = null);
        void Exit();
        void Update(float deltaTime);
    }
}
