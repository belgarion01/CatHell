using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class StateCatPatrol : StateCat
{
   [SerializeField]
  private float _angularSpeed;
  [SerializeField]
  private float _speed;
  [SerializeField]
  private float _minLength;
  [SerializeField]
  private float _maxLength;
  [SerializeField]
  private float _timePatrol;
  
  private float _timerPatrol;
  
  [SerializeField]
  private List<StateCatProbability> _stateCatProbabilitiesList;
  public override void ToMutation()
  {
      base.ToMutation();
      StateCatPatrol mutationStateType = (StateCatPatrol) MutationState;
      _angularSpeed = mutationStateType._angularSpeed;
      _speed = mutationStateType._speed;
      _minLength = mutationStateType._minLength;
      _maxLength = mutationStateType._maxLength;
      _timePatrol = mutationStateType._timePatrol;
      _stateCatProbabilitiesList.Clear();
      _stateCatProbabilitiesList.AddRange(mutationStateType._stateCatProbabilitiesList);
  }

  public override void StartState()
  {
    _machineCat.Agent.speed = _speed;
    _machineCat.Agent.angularSpeed = _angularSpeed;
    _timerPatrol = 0; 
  GenerateDestination();
  }

 void GenerateDestination()
  {
    Vector2 _dir = Random.insideUnitCircle.normalized;
   float _length =  Random.Range(_minLength, _maxLength);
   NavMeshHit _hit;
   NavMesh.SamplePosition(_machineCat.transform.position + new Vector3(_dir.x, _machineCat.transform.position.y, _dir.y),
       out _hit, _length, 1);
   _machineCat.Agent.SetDestination(_hit.position);
  }
 public override void UpdateState()
  {
    if (Vector3.Distance(_machineCat.transform.position, _machineCat.Agent.destination)<_machineCat.Agent.radius)
    {
      GenerateDestination();
    }

    if (_timerPatrol < _timePatrol)
     _timerPatrol += Time.deltaTime;
    else
    {
      EndPatrol();
    }
  }

 public virtual void EndPatrol()
 {
     float _rand = Random.Range(0, 100);
     for (int i = 0; i < _stateCatProbabilitiesList.Count; i++)
     {
         if (_stateCatProbabilitiesList[i].CheckFloatInProbability(_rand))
             NextState = _stateCatProbabilitiesList[i].stateCat;
     }
 }
}
