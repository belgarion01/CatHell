
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class StateCatPatrol : StateCat
{
    [SerializeField]
    private float angularSpeedFactor;
    [SerializeField]
    private float speedFactor;
  [SerializeField]
  private float _minLength;
  [SerializeField]
  private float _maxLength;
  [SerializeField]
  private float _timePatrol;
  
  private float _timerPatrol;
  
  [SerializeField]
  private List<StateCatProbability> _stateCatProbabilitiesList;
  
  public override void StartState()
  {
      _cat.Agent.isStopped = false;
    _cat.Agent.speed = _cat.Speed*speedFactor;
        _cat.Agent.angularSpeed = _cat.AngularSpeed*angularSpeedFactor;
    _timerPatrol = 0;
    GenerateDestination();
    
    _cat.AnimSetWalking();
  }

 void GenerateDestination()
  {
    Vector2 _dir = Random.insideUnitCircle.normalized;
   float _length =  Random.Range(_minLength, _maxLength);
   NavMeshHit _hit;
   NavMesh.SamplePosition(_cat.transform.position + new Vector3(_dir.x, _cat.transform.position.y, _dir.y),
       out _hit, _length, 1);
   _cat.Agent.SetDestination(_hit.position);
  }
 public override void UpdateState()
  {
      
    if (Vector3.Distance(_cat.transform.position, _cat.Agent.destination)<_cat.Agent.radius)
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
