using System.Collections.Generic;
using Managers;
using UnityEngine;

public class Cover : MonoBehaviour, ICover
{
    public List<Transform> CoverPoints => _coverPoints;
    [SerializeField] protected List<Transform> _coverPoints;

    public Vector3 GetProperPosition()
    {
        return CoverPoints[0].position;
    }
}
