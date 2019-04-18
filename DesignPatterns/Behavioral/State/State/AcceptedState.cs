namespace State.State
{
	public class AcceptedState : StateBase
	{
		public override void Edit(ProcessState a_processState)
		{
			a_processState.SetState(EDITED);
		}

	   /// <summary>
	   /// Nazwa Stanu
	   /// </summary>
	   public override string Name
	   {
         get { return StateName.ACCEPTED; }
	   }
	}
}