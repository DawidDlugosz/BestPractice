namespace State
{
   public interface IProcessState
   {
      void Edit();
      void Save();
      void Clear();
      string CurrentState { get; }
   }
}