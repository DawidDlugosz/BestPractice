namespace State.NotPattern
{
	public class SimpleProcessState : IProcessState
	{
		public const int NEW = 0;
		public const int EDITED = 1;
		public const int SAVED = 2;
	   public const int ERROR = 3;
	   public const int ACCEPTED = 4;


	   private int m_state;

		public SimpleProcessState() 
         :this(NEW)
		{}

		public SimpleProcessState(int a_startState)
		{
			m_state = a_startState;
		   ValidationResult = true;
		}

      public bool ValidationResult { get; set; }

		/// <summary>
		/// Aktualizacja stanu
		/// </summary>
		/// <param name="a_newState"></param>
		internal void SetState(int a_newState)
		{
			m_state = a_newState;
		}

		public void Edit()
		{
		   if (m_state != ERROR)
		   {
		      SetState(EDITED);
		   }
		}

		public void Save()
		{
			if (m_state == NEW || m_state == ACCEPTED)
			{
			}
			else if (m_state == EDITED || m_state == ERROR)
			{
				SetState(SAVED);
			}
			else if (m_state == SAVED && ValidationResult)
			{
				SetState(ACCEPTED);
			}
			else if(m_state == SAVED && ValidationResult == false)
			{
			   SetState(ERROR);
			}
		}

		public void Clear()
		{
		   if (m_state != ACCEPTED)
		   {
		      SetState(NEW);
		   }
		}


		public string CurrentState
		{
			get
			{
				switch (m_state)
				{
					case NEW:
						return StateName.NEW;
					case EDITED:
						return StateName.EDITED;
					case SAVED:
						return StateName.SAVED;
					case ACCEPTED:
						return StateName.ACCEPTED;
               case ERROR:
				      return StateName.ERROR;
					default:
						return StateName.NEW;
				}
			}
		}
	}
}