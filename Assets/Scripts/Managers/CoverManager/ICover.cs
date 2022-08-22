using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public interface ICover
    {
        List<Transform> CoverPoints { get; }
    }
}