using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCatSick : StateCat
{
    [SerializeField]
    private float mutationValue;
    public override void StartState()
    {
        _cat.Agent.isStopped = true;
    }

    public override void UpdateState()
    {
        _cat.Mutation.CurrentMutation += mutationValue*Time.deltaTime;
    }
}
