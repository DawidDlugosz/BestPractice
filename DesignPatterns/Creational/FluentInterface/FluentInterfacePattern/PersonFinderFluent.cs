using System.Collections.Generic;
using FluentInterface.TraditionalCode;

namespace FluentInterface.FluentInterfacePattern
{
   public class PersonFinderFluent
   {
      public string m_firstName;
      public string m_lastName;
      public string m_address;
      public string m_correspondenceAddress;
      public bool m_includePhoto;

      public PersonFinderFluent FirstName(string a_firstName)
      {
         m_firstName = a_firstName;
         return this;
      }

      public PersonFinderFluent LastName(string a_lastName)
      {
         m_lastName = a_lastName;
         return this;
      }
      public PersonFinderFluent Address(string a_address)
      {
         m_lastName = a_address;
         return this;
      }
      
      public PersonFinderFluent CorrespondenceAddress(string a_correspondenceAddress)
      {
         m_lastName = a_correspondenceAddress;
         return this;
      }

      public PersonFinderFluent IncludePhoto
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