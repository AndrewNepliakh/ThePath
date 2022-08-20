using System.Collections;
using Managers;
using UnityEngine;


public class UnitMover : MonoBehaviour, IUnitMover
{
    private float _speed = 1.0f; 
    
    public void Init(UnitMoverArguments args)
    {
        _speed = args.Speed;
    }

    public void Move(Vector3 coordinates)
    {
        StartCoroutine(MoveRoutine(coordinates));
    }

    private IEnumerator MoveRoutine(Vector3 coordinates)
    {
        while (Vector3.Distance(transform.position, coordinates) < 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, coordinates, Time.deltaTime * _speed);
            yield return null;
        }

        transform.position = coordinates;
    }
}