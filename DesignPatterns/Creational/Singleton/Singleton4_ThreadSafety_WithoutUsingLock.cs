namespace Singleton
{
   /// <summary>
   /// Statyczny konstruktor pozwala stworzyć tylko jedną instancję w AppDomain
   /// Minusy:
   /// 1. Nie jest aż tak Lazy 
   /// 2. Jest problem w przypadku gdy statyczny konstruktor wywołuje kolejny statyczny konstruktor, 
   ///    który ponownie odwołuje się do pierwszego
   /// </summary>
	public sealed class Singleton4_ThreadSafety_WithoutUsingLock
	{
		static readonly Singleton4_ThreadSafety_WithoutUsingLock m_instance = new Singleton4_ThreadSafety_WithoutUsingLock();

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static Singleton4_ThreadSafety_WithoutUsingLock()
    {
    }

    Singleton4_ThreadSafety_WithoutUsingLock()
    {
    }

    public static Singleton4_ThreadSafety_WithoutUsingLock Instance
    {
        get
        {
            return m_instance;
        }
    } 
	}
}