

using UnityEngine;

public class StateCatTimerAction : StateCatWait
{
   [SerializeField] private float _mutationAmount;
   

   public override void StartState()
   {
       base.StartState();
       _cat.AnimSetIdle();
       _cat.ScratchEffect.SetActive(true);
   }

   public override void EndWait()
   {
       _cat.Mutation.CurrentMutation += _mutationAmount++;
      NextState = _endWaitState;
      _cat.ScratchEffect.SetActive(false);

   }
}
