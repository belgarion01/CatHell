using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


public class MachineCat : MonoBehaviour
{

   public List<StateCat> StateCatList;
   [ReadOnly]
   public StateCat CurrentStateCat;
   private bool _isStartCurrentStateCat;

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
      CurrentStateCat = StateCatList[0];
   }
   private void Update()
   {
      if (CurrentStateCat.NextState != null)
      {
         _isStartCurrentStateCat = true;
         StateCat oldStateCat = CurrentStateCat;
         CurrentStateCat = CurrentStateCat.NextState;
         oldStateCat.NextState = null;
         
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
