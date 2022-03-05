using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public  class StateCat : MonoBehaviour
{
 
[ReadOnly] [SerializeField]
 protected MachineCat _machineCat;
[ReadOnly]
public StateCat NextState;
public StateCatEnum StateCatEnum;
public StateCat MutationState;
[Button]
public void SetMachineCat()
{
 _machineCat = GetComponent<MachineCat>();
}
virtual public void ToMutation()
{
 if(MutationState.MutationState != null)
 MutationState = MutationState.MutationState;
}

 virtual public void StartState()
 {

 }

 virtual public void UpdateState()
 {

 }

 virtual public void FixedUpdateState()
 {
  
 }

 public virtual void OnTriggerEnter(Collider other)
 {

 }

 virtual public void OnTriggerExit(Collider other)
 {

 }

 virtual public void OnTriggerStay(Collider other)
 {
     
 }
  
}
