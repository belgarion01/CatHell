 
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class StateCatMoveToPoint :  StateCat
{
    [SerializeField]
    private List<StateCatDestination> _stateCatDestinationList;
    private Vector3 _destination;
    private StateCat _stateCatDest;

    private void Start()
    {
        foreach (StateCatDestination stateCatDestination in _stateCatDestinationList)
        {
            stateCatDestination.destination =
                DestinationCat.instance.destinationCatClassDic[stateCatDestination.destinationCatEnum];
        }
    }

    [SerializeField]
    private float angularSpeedFactor;
    [SerializeField]
    private float speedFactor;

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
        _cat.Agent.speed = _cat.Speed*speedFactor;
        _cat.Agent.angularSpeed = _cat.AngularSpeed*angularSpeedFactor;
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
