namespace State.State
{
	public class EditedState : StateBase
	{
		public override void Save(ProcessState a_processState)
		{
			a_processState.SetState(SAVED);
		}

		public override void Clear(ProcessState a_processState)
		{
			a_processState.SetState(NEW);
		}

	   /// <summary>
	   /// Nazwa Stanu
	   /// </summary>
	   public override string Name
	   {
         get { return StateName.EDITED; }
	   }
	}
}