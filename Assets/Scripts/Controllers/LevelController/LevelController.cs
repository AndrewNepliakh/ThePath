using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public List<Cover> Covers { get; }

    [SerializeField] private List<Cover> _covers = new();
}
