using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

public class MachineCat : MonoBehaviour
{

   public NavMeshAgent Agent;
   public List<StateCat> StateCatList;
   [ReadOnly]
   public StateCat CurrentStateCat;
   private bool _isStartCurrentStateCat;
[SerializeField] int _maxMutation;
   private int _currentMutation;
   public List<StateCat> MutateStateAddList;
   public Animator Animator;
   public MeshFilter MeshFilter;
   public MachineCat MutateMachineCat;
   public int CurrentMutation
   {
      get
      {
         return _currentMutation;
      }

      set
      {
         _currentMutation = value;
         if (_currentMutation == _maxMutation)
         {
            Animator.runtimeAnimatorController = MutateMachineCat.Animator.runtimeAnimatorController;
            MeshFilter.mesh = MutateMachineCat.MeshFilter.mesh;
            StateCatList.AddRange(MutateStateAddList);
            for (int i = 0; i < MutateStateAddList.Count; i++)
            {
              StateCat stateCat = (StateCat) gameObject.AddComponent(MutateStateAddList[i].GetType());
              stateCat.MutationState = MutateStateAddList[i];
              stateCat.ToMutation();
              stateCat.MutationState = MutateStateAddList[i].MutationState;
            }
            
             foreach (var stateCat in StateCatList)
            {
               stateCat.ToMutation();
            }
         }
      }
   }

   public void SetState(StateCatEnum stateCatEnum)
   {
      _isStartCurrentStateCat = true;
      CurrentStateCat.NextState = null;
      for (int i = 0; i < StateCatList.Count; i++)
      {
         if (stateCatEnum == StateCatList[i].StateCatEnum)
         {
            CurrentStateCat = StateCatList[i];
            break;
         }
      } 
      
   }
   
   private void Start()
   {
      
   }
   private void Update()
   {
      if (CurrentStateCat.NextState != null)
      {
         _isStartCurrentStateCat = true;
         CurrentStateCat.NextState = null;
         CurrentStateCat = CurrentStateCat.NextState;
      }
      
      if (_isStartCurrentStateCat)
      {
           CurrentStateCat.StartState();
           _isStartCurrentStateCat = false;
      }
      else
      {
         CurrentStateCat.UpdateState();
      }
      
   }
   private void FixedUpdate()
   {
      if (_isStartCurrentStateCat) return; 
      CurrentStateCat.FixedUpdateState();
   }

   private void OnTriggerEnter(Collider other)
   {
      if (_isStartCurrentStateCat) return; 
      CurrentStateCat.OnTriggerEnter(other);
   }

   private void OnTriggerExit(Collider other)
   {
      if (_isStartCurrentStateCat) return; 
      CurrentStateCat.OnTriggerExit(other);
   }

   private void OnTriggerStay(Collider other)
   {
      if (_isStartCurrentStateCat) return; 
      CurrentStateCat.OnTriggerStay(other);
   }
   
}
