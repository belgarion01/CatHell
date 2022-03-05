
using Sirenix.OdinInspector;
using UnityEngine;

public  class StateCat : MonoBehaviour
{
 protected Cat _cat;
[ReadOnly]
public StateCat NextState;
public StateCatEnum StateCatEnum;
public StateCat MutationState;
private void OnValidate()
{
 if(_cat == null)
  _cat = GetComponent<Cat>();
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
