

public class StateCatTimerAction : StateCatWait
{
   

   
   public override void ToMutation()
   {
      base.ToMutation();
      StateCatTimerAction mutationType = (StateCatTimerAction) MutationState;
      _endWaitState = mutationType._endWaitState;
   }

   public override void EndWait()
   {
      
      _cat.Mutation.CurrentMutation++;
      NextState = _endWaitState;

   }
}
