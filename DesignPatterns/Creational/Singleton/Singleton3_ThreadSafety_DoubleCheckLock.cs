namespace Singleton
{
   /// <summary>
   /// 1. Nie działa w języku Java
   /// 2. Trzeba pamiętać dokładną kolejność sprawdzania i blokowania
   /// </summary>
	public sealed class Singleton3_ThreadSafety_DoubleCheckLock
	{
		static Singleton3_ThreadSafety_DoubleCheckLock m_instance=null;
		static readonly object m_lock = new object();

		Singleton3_ThreadSafety_DoubleCheckLock()
		{}

		public static Singleton3_ThreadSafety_DoubleCheckLock Instance
		{
			get
			{
				if (m_instance==null)
				{
						lock (m_lock)
						{
							if (m_instance==null)
							{
								m_instance = new Singleton3_ThreadSafety_DoubleCheckLock();
							}
						}
				}
				return m_instance;
			}
		} 
	}
}