using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator
{
	/// <summary>
	/// The 'Mediator' abstract class
	/// </summary>
	public abstract class AbstractChatroom
	{
		public abstract void Register(Participant a_participant);
		public abstract void Send(string a_from, string a_to, string a_message);
	}

	/// <summary>
	/// The 'ConcreteMediator' class
	/// </summary>
	public class Chatroom : AbstractChatroom
	{
		private readonly Dictionary<string, Participant> m_participants =
			 new Dictionary<string, Participant>();

		public override void Register(Participant a_participant)
		{
			if (!m_participants.ContainsValue(a_participant))
			{
				m_participants[a_participant.Name] = a_participant;
			}

			a_participant.Chatroom = this;
		}

		public override void Send(string a_from, string a_to, string a_message)
		{
			if(a_to == null)
			{
				m_participants
					.ToList()
					.Where(a_kvp => a_kvp.Key != a_from)
					.ToList()
					.ForEach(a_kvp => a_kvp.Value.Receive(a_from, a_message));
				return;
			}
			Participant participant = m_participants[a_to];

			if (participant != null)
			{
				participant.Receive(a_from, a_message);
			}
		}
	}

	/// <summary>
	/// The 'AbstractColleague' class
	/// </summary>
	public class Participant
	{
		private Chatroom m_chatroom;
		private readonly string m_name;

		// Constructor
		public Participant(string a_name)
		{
			m_name = a_name;
		}

		// Gets participant name
		public string Name
		{
			get { return m_name; }
		}

		// Gets chatroom
		public Chatroom Chatroom
		{
			set { m_chatroom = value; }
			get { return m_chatroom; }
		}

		// Sends message to given participant
		public void Send(string a_message)
		{
			Send(null, a_message);
		}

		public void Send(string a_to, string a_message)
		{
			m_chatroom.Send(m_name, a_to, a_message);
		}

		// Receives message from given participant
		public virtual void Receive(string a_from, string a_message)
		{
			Console.WriteLine("{0} dostaje wiadomość od {1}: '{2}'",
				 Name, a_from, a_message);
		}
	}
}
