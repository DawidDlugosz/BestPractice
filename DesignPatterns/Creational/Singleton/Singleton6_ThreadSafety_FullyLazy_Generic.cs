using System;

namespace Singleton
{
	public sealed class Singleton6_ThreadSafety_FullyLazy_Generic<T>
		where T : new()
	{
		private DateTime m_createdDate = DateTime.UtcNow;

		private Singleton6_ThreadSafety_FullyLazy_Generic() { }

		public DateTime CreatedDate
		{
			get { return m_createdDate; }
		}

		public static T Generate
		{
			get { return SingletonCreator.Sm_Instance; }
		}

		private class SingletonCreator
		{
			static SingletonCreator() { }

			internal static readonly T Sm_Instance = new T();
		}
	}
}