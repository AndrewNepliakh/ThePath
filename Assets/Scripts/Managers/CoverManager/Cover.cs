using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;

public class Cover : MonoBehaviour, ICover
{
    public List<Transform> CoverPoints { get; }
    [SerializeField] protected List<Transform> _coverPoints;
    
}
