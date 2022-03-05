
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateCatMoveToPoint :  StateCat
{
    [SerializeField]
    private List<StateCatDestination> _stateCatDestinationList;

    private Vector3 _destination;
    private StateCat _stateCatDest;
    public override void ToMutation()
    {
        base.ToMutation();
        StateCatMoveToPoint mutationStateType = (StateCatMoveToPoint) MutationState;
        _angularSpeed = mutationStateType._angularSpeed;
        _speed = mutationStateType._speed;
        _stateCatDestinationList.Clear();
        _stateCatDestinationList.AddRange(mutationStateType._stateCatDestinationList);
        
    }
[SerializeField]
    private float _angularSpeed;
    [SerializeField]  private float _speed;
    public override void StartState()
    {
        NavMeshHit _hit;
        float rand = Random.Range(0, 100);
        for (int i = 0; i < _stateCatDestinationList.Count; i++)
        {
            if (_stateCatDestinationList[i].CheckFloatInProbability(rand))
            {
                _destination = _stateCatDestinationList[i].destination.position;
                _stateCatDest = _stateCatDestinationList[i].stateCat;

            }
        }
        NavMesh.SamplePosition(_destination, out _hit, Vector3.Distance(transform.position, _destination), 1 );
        _destination = _hit.position;
           _cat.Agent.SetDestination(_destination);
        _cat.Agent.speed = _speed;
        _cat.Agent.angularSpeed = _angularSpeed;
    }

    public override void UpdateState()
    {
       Debug.Log(Vector3.Distance(_cat.Agent.transform.position, _destination) );
        if (Vector3.Distance(transform.position, _destination) <= _cat.Agent.radius)
        {
            NextState = _stateCatDest;
        }
        
    }
}
