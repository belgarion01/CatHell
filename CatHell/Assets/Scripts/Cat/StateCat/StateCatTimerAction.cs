

using UnityEngine;

public class StateCatTimerAction : StateCatWait
{
   [SerializeField] private float _mutationAmount;
   public override void EndWait()
   {
      
     _cat.Mutation.CurrentMutation += _mutationAmount++;
      NextState = _endWaitState;

   }
}
