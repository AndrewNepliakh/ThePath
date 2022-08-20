using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Cover : MonoBehaviour
{
    public List<Transform> CoverPoints { get; }

    public Cover()
    {
        _coverPoints = new List<Transform>();
    }

    [SerializeField] protected List<Transform> _coverPoints;
    
}
