using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Singleton
{
	/// <summary>
	/// Najprostrza wersja singletonu działająca w aplikacjach wielowątkowych
	/// </summary>
	public sealed class Singleton2_ThreadSafety_Simple
	{
		static Singleton2_ThreadSafety_Simple m_instance = null;
		static readonly object m_lock = new object();

		private Singleton2_ThreadSafety_Simple()
		{
		}

		public static Singleton2_ThreadSafety_Simple Instance
		{
			get
			{
				lock (m_lock)
				{
					if (m_instance == null)
					{
						m_instance = new Singleton2_ThreadSafety_Simple();
					}
					return m_instance;
				}
			}
		}
	}
}
