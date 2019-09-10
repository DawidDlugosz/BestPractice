namespace State.State
{
	public class NewState : StateBase
	{
		/// <summary>
		/// Edycja
		/// </summary>
		public override void Edit(ProcessState a_processState)
		{
			a_processState.SetState(EDITED);
		}

	   /// <summary>
	   /// Nazwa Stanu
	   /// </summary>
	   public override string Name
	   {
         get { return StateName.NEW; }
	   }
	}
}