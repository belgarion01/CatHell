using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StateCatIdle : StateCatWait
{
    [SerializeField]
    private List<StateCatProbability> _stateCatProbabilitiesList;
    [SerializeField]
    private float _minTimeIdle;
    [SerializeField]
    private float _maxTimeIdle;
    public override void StartState()
    {
        base.StartState();
        _cat.AnimSetIdle();
        _timeWait = Random.Range(_minTimeIdle, _maxTimeIdle);
    }
    public override void EndWait()
    {
        float rand = Random.Range(0, 100);
        for (int i = 0; i < _stateCatProbabilitiesList.Count; i++)
        {
            if (_stateCatProbabilitiesList[i].CheckFloatInProbability(rand))
                NextState = _stateCatProbabilitiesList[i].stateCat;
        }
    }
   
    
}
