using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCatWait : StateCat

{[SerializeField]
    private float _timePatrol;
    private float _timerPatrol;
    [SerializeField]
    private StateCat _endWaitState;
    public override void ToMutation()
    {
        base.ToMutation();
        StateCatWait mutationStateType = (StateCatWait) MutationState;
        _timePatrol = mutationStateType._timePatrol;
        _endWaitState = mutationStateType._endWaitState;
        
    }

    public override void StartState()
    {
        _timerPatrol = 0;
    }

    public override void UpdateState()
    {
        if (_timerPatrol < _timePatrol)
            _timerPatrol += Time.deltaTime;
        else
        {
            EndWait();
        }
    }

    
    public virtual void EndWait()
    {
        NextState = _endWaitState;
    }
}
