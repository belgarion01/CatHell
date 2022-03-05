using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class StateCatWait : StateCat

{[SerializeField]
    private float _timeWait;
    private float _timerWait;
    [SerializeField]
    [HideIf("_hideEndWaitState")]
    protected StateCat _endWaitState;

    private bool _hideEndWaitState => GetType() == typeof(StateCatIdle) ; 
    public override void ToMutation()
    {
        base.ToMutation();
        StateCatWait mutationStateType = (StateCatWait) MutationState;
        _timeWait = mutationStateType._timeWait;
        _endWaitState = mutationStateType._endWaitState;
        
    }

    
    public override void StartState()
    {
        _timerWait = 0;
    }

    public override void UpdateState()
    {
        if (_timerWait < _timeWait)
        {
            _timerWait += Time.deltaTime;
        }
            
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
