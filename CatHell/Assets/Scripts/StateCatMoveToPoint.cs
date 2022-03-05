using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateCatMoveToPoint :  StateCat
{
    public override void ToMutation()
    {
        base.ToMutation();
        StateCatMoveToPoint mutationStateType = (StateCatMoveToPoint) MutationState;
        _angularSpeed = mutationStateType._angularSpeed;
        _speed = mutationStateType._speed;
        _destination = mutationStateType._destination;
        _destinationState = mutationStateType._destinationState;
        
    }
[SerializeField]
    private float _angularSpeed;
    [SerializeField]  private float _speed;
    [SerializeField]  private Transform _destination;
    [SerializeField] private StateCat _destinationState;
    public override void StartState()
    {
        _machineCat.Agent.SetDestination(_destination.position);
        _machineCat.Agent.speed = _speed;
        _machineCat.Agent.angularSpeed = _angularSpeed;
    }

    public override void UpdateState()
    {
        if (Vector3.Distance(_machineCat.transform.position, _destination.position) < 0.3f)
        {
            _destinationState = NextState;
        }
        
    }
}
