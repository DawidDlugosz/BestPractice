namespace State.State
{
	public class SavedState : StateBase
	{
	   public SavedState() 
         : this(true)
	   {
	   }

	   public SavedState(bool a_validationResult)
	   {
	      ValidationResult = a_validationResult;
	   }

	   public override void Edit(ProcessState a_processState)
		{
			a_processState.SetState(EDITED);
		}

      private bool Validation()
      {
         return ValidationResult;
      }

	   public override void Save(ProcessState a_processState)
	   {
	      a_processState.SetState(Validation() ? ACCEPTED : ERROR);
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
         get { return StateName.SAVED; }
	   }
	}
}