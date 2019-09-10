using System.Collections.Generic;
using FluentInterface.TraditionalCode;

namespace FluentInterface.FluentInterfacePattern
{
   public class PersonFinderFluentInterfaceSecondSteps : IPersonFinderFluentInterfaceSecondSteps
   {
      public string m_firstName;
      public string m_lastName;
      public bool m_includePhoto;
      readonly IPersonFinderFirstStepsConfiguration m_personFinderFluentInterfaceSteps;

      public PersonFinderFluentInterfaceSecondSteps(IPersonFinderFirstStepsConfiguration a_personFinderFluentInterfaceSteps)
      {
         m_personFinderFluentInterfaceSteps = a_personFinderFluentInterfaceSteps;
      }

      public IPersonFinderFluentInterfaceSecondSteps SetFirstName(string a_firstName)
      {
         m_firstName = a_firstName;
         return this;
      }

      public IPersonFinderFluentInterfaceSecondSteps SetLastName(string a_lastName)
      {
         m_lastName = a_lastName;
         return this;
      }

      public IPersonFinderFluentInterfaceSecondSteps IncludePhoto
      {
         get
         {
            m_includePhoto = true;
            return this;
         }
      }

      public List<Person> Find()
      {
         //Do something
         var adres = m_personFinderFluentInterfaceSteps.Address;
         var correAdr = m_personFinderFluentInterfaceSteps.CorrespondenceAddress;
         var nip = m_personFinderFluentInterfaceSteps.NIP;
         var pid = m_personFinderFluentInterfaceSteps.PID;
         return new List<Person>();
      }
      
   }
}