using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurGenerator : MonoBehaviour
{
    [SerializeField] private Fur _furPrefab;
    [SerializeField] private float _timeBetweenGeneration = 4f;
    [SerializeField] private Cat cat;
    
    public float TimeBetweenGeneration
    {
        get => _timeBetweenGeneration;
        set => _timeBetweenGeneration = value;
    }
    private float _tickTimer;
    
    private void Update()
    {
        if (cat.isHoldable)
            return;
        _tickTimer += Time.deltaTime;

        if (_tickTimer >= _timeBetweenGeneration)
        {
            GenerateFur();
            _tickTimer = 0f;
        }
    }

    private void GenerateFur()
    {
        Instantiate(_furPrefab, transform.position, _furPrefab.transform.rotation);
    }
}
