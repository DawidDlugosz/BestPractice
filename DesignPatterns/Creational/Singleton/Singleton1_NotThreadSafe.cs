namespace Singleton
{
	public sealed class Singleton1_NotThreadSafe 
	{
		static Singleton1_NotThreadSafe m_instance=null;
		private int m_counter = 0;

		Singleton1_NotThreadSafe()
		{
		}

		public static Singleton1_NotThreadSafe Instance
		{
			get
			{
				if (m_instance==null)
				{
					m_instance = new Singleton1_NotThreadSafe();
				}
				return m_instance;
			}
		}
	}
}