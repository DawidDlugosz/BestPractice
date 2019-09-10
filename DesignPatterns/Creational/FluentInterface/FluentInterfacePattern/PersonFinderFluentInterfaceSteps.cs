using System.Collections.Generic;
using FluentInterface.TraditionalCode;

namespace FluentInterface.FluentInterfacePattern
{
   #region [Interfaces]

   public interface IPersonFinderFluentInterfaceFirstSteps : IPersonFinderConfigurationFirstSteps
   {
   }

   public interface IPersonFinderConfigurationFirstSteps
   {
      IPersonFinderFluentInterfaceSecondSteps SetAddress(string a_address);
      IPersonFinderFluentInterfaceSecondSteps SetCorrespondenceAddress(string a_correspondenceAddress);
      IPersonFinderFluentInterfaceSecondSteps SetPesel(string a_pesel);
      IPersonFinderFluentInterfaceSecondSteps SetNIP(string a_nip);
      IPersonFinderFluentInterfaceSecondSteps SetPID(string a_pid);
   }

   public interface IPersonFinderFirstStepsConfiguration
   {
      string Address { get; }
      string CorrespondenceAddress { get; }
      string Pesel { get; }
      string NIP { get; }
      string PID { get; }
   }

   public interface IPersonFinderFluentInterfaceSecondSteps : IPersonFinderEndingMethod
   {
      IPersonFinderFluentInterfaceSecondSteps SetFirstName(string a_firstName);
      IPersonFinderFluentInterfaceSecondSteps SetLastName(string a_lastName);
      IPersonFinderFluentInterfaceSecondSteps IncludePhoto { get; }
   }

   public interface IPersonFinderStepsEndingMethod
   {
      List<Person> Find();
   }

   #endregion

   public class PersonFinderFluentInterfaceSteps : IPersonFinderFluentInterfaceFirstSteps, IPersonFinderFirstStepsConfiguration
   {
      private readonly IPersonFinderFluentInterfaceSecondSteps m_secondSteps;
      public string m_pesel;
      public string m_nip;
      public string m_pid;
      public string m_address;
      public string m_correspondenceAddress;

      public PersonFinderFluentInterfaceSteps()
      {
         m_secondSteps = new PersonFinderFluentInterfaceSecondSteps(this);
      }

      public IPersonFinderFluentInterfaceSecondSteps SetAddress(string a_address)
      {
         m_address = a_address;
         return m_secondSteps;
      }

      public IPersonFinderFluentInterfaceSecondSteps SetPesel(string a_pesel)
      {
         m_pesel = a_pesel;
         return m_secondSteps;
      }

      public IPersonFinderFluentInterfaceSecondSteps SetNIP(string a_nip)
      {
         m_nip = a_nip;
         return m_secondSteps;
      }

      public IPersonFinderFluentInterfaceSecondSteps SetPID(string a_pid)
      {
         m_pid = a_pid;
         return m_secondSteps;
      }

      public IPersonFinderFluentInterfaceSecondSteps SetCorrespondenceAddress(string a_correspondenceAddress)
      {
         m_correspondenceAddress = a_correspondenceAddress;
         return m_secondSteps;
      }

      public string Address { get { return m_address; } }
      public string CorrespondenceAddress { get { return m_correspondenceAddress; } }
      public string Pesel { get { return m_pesel; } }
      public string NIP { get { return m_nip; } }
      public string PID { get { return m_pid; } }
   }
}