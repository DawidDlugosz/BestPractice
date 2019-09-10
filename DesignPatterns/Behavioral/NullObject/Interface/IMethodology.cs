using System;

namespace NullObject.Interface
{
   public interface IMethodology
   {
      string Name { get; }
      Guid Key { get; }
      void DoSomething();
      void ImportantMethod(string a_value);
   }
}