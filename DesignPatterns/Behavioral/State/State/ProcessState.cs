namespace State.State
{
   public class ProcessState : IProcessState
   {
		private StateBase m_state;

		public ProcessState()
		{
			m_state = StateBase.NEW;
		}

		public ProcessState(StateBase a_startState)
		{
			m_state = a_startState;
		}

		/// <summary>
		/// Aktualizacja stanu
		/// </summary>
		/// <param name="a_newState"></param>
		internal void SetState(StateBase a_newState)
		{
			m_state = a_newState;
		}

		public void Edit()
		{
			m_state.Edit(this);
		}

		public void Save()
		{
			m_state.Save(this);
		}

		public void Clear()
		{
			m_state.Clear(this);
		}

		public string CurrentState
		{
			get { return m_state.Name; }
		}
	}
}