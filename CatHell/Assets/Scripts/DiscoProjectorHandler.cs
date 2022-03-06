using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiscoProjectorHandler : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _projectors = new List<Transform>();

    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _timeBeforeChanginDirection = 3f;

    private List<Vector3> _projectorDirection = new List<Vector3>();

    private float _tickTimer;

    private void Start()
    {
        RandomizeDirections();
    }

    private void Update()
    {
        for (int i = 0; i < _projectors.Count; i++)
        {
            if(i >= _projectorDirection.Count)
                continue;
            
            _projectors[i].Rotate(_projectorDirection[i], _rotationSpeed * Time.deltaTime);
        }

        _tickTimer += Time.deltaTime;

        if (_tickTimer >= _timeBeforeChanginDirection)
        {
            RandomizeDirections();
            _tickTimer = 0f;
        }
    }

    private void RandomizeDirections()
    {
        _projectorDirection.Clear();
        
        for (int i = 0; i < _projectors.Count; i++)
        {
            _projectorDirection.Add(Random.insideUnitSphere);
        }
    }
}
