using System;

namespace State.State
{
	public abstract class StateBase
	{
		public static readonly StateBase NEW = new NewState();
		public static readonly StateBase EDITED = new EditedState();
		public static readonly StateBase SAVED = new SavedState();
		public static readonly StateBase ERROR = new WalidationErrorState();
		public static readonly StateBase ACCEPTED = new AcceptedState();

		/// <summary>
		/// Edycja
		/// </summary>
		public virtual void Edit(ProcessState a_processState)
		{}

      public bool ValidationResult { get; set; }

		/// <summary>
		/// Zapis
		/// </summary>
		public virtual void Save(ProcessState a_processState)
		{}

		/// <summary>
		/// Wyczyść
		/// </summary>
		public virtual void Clear(ProcessState a_processState)
		{}

      /// <summary>
      /// Nazwa Stanu
      /// </summary>
	   public abstract string Name { get; }

		/// <summary>
		/// 
		/// </summary>
		public ProcessState ProcessState { get; set; }
	}
}
