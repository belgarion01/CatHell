using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCatTimerAction : StateCatWait
{
   [SerializeField]
   private StateCat _endWaitState;

   public override void ToMutation()
   {
      base.ToMutation();
      StateCatTimerAction mutationType = (StateCatTimerAction) MutationState;
      _endWaitState = mutationType._endWaitState;
   }

   public override void UpdateState()
   {
      base.UpdateState();
   }
   
   public override void EndWait()
   {
      _machineCat.CurrentMutation++;
      NextState = _endWaitState;

   }
}
