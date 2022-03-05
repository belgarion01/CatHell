using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StateCatIdle : StateCatWait
{
    public override void ToMutation()
    {
        base.ToMutation();
        StateCatIdle mutationStateType = (StateCatIdle) MutationState;
        _stateCatProbabilitiesList.Clear();
      _stateCatProbabilitiesList.AddRange(mutationStateType._stateCatProbabilitiesList);  
    }
    [SerializeField]
    private List<StateCatProbability> _stateCatProbabilitiesList;
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
