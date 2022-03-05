

public class StateCatTimerAction : StateCatWait
{ 
   public override void EndWait()
   {
      
      _cat.Mutation.CurrentMutation++;
      NextState = _endWaitState;

   }
}
