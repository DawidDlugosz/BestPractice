using System.Collections.Generic;
using FluentInterface.TraditionalCode;

namespace FluentInterface.FluentInterfacePattern
{

   #region [Interfaces]

   public interface IPersonFinderEndingMethod
   {
      List<Person> Find();
   }

   public interface IPersonFinderConfiguration
   {
      IPersonFinderFluentInterface FirstName(string a_firstName);
      IPersonFinderFluentInterface LastName(string a_lastName);
      IPersonFinderFluentInterface Address(string a_address);

      IPersonFinderFluentInterface CorrespondenceAddress(
         string a_correspondenceAddress);

      IPersonFinderFluentInterface IncludePhoto { get; }
   }

   public interface IPersonFinderFluentInterface : IPersonFinderConfiguration,
                                                   IPersonFinderEndingMethod
   {
   }

   #endregion
   
   public class PersonFinderFluentInterface : IPersonFinderFluentInterface
   {
      public string m_firstName;
      public string m_lastName;
      public string m_address;
      public string m_correspondenceAddress;
      public bool m_includePhoto;

      public IPersonFinderFluentInterface FirstName(string a_firstName)
      {
         m_firstName = a_firstName;
         return this;
      }

      public IPersonFinderFluentInterface LastName(string a_lastName)
      {
         m_lastName = a_lastName;
         return this;
      }
      public IPersonFinderFluentInterface Address(string a_address)
      {
         m_lastName = a_address;
         return this;
      }

      public IPersonFinderFluentInterface CorrespondenceAddress(string a_correspondenceAddress)
      {
         m_lastName = a_correspondenceAddress;
         return this;
      }

      public IPersonFinderFluentInterface IncludePhoto
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
         return new List<Person>();
      }
   }
}