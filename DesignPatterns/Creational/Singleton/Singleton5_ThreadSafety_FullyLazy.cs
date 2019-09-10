namespace Singleton
{
   /// <summary>
   /// Jest w pełni Lazy
   /// </summary>
	public sealed class Singleton5_ThreadSafety_FullyLazy
	{
		private Singleton5_ThreadSafety_FullyLazy()
		{
		}

		public static Singleton5_ThreadSafety_FullyLazy Instance
		{
			get
			{
				return SingletonConstructor.m_instance;
			}
		}
    
		private class SingletonConstructor
		{
			static SingletonConstructor()
			{
			}

			internal static readonly Singleton5_ThreadSafety_FullyLazy m_instance 
				= new Singleton5_ThreadSafety_FullyLazy();
      } 
	}
}