using System.Collections.Generic;

namespace FluentInterface.TraditionalCode
{
   public class PersonFinder
   {
      public PersonFinder()
      {}

      public PersonFinder(string a_firstName, string a_lastName, string a_address, string a_correspondenceAddress, bool a_includePhoto)
      {
         FirstName = a_firstName;
         LastName = a_lastName;
         Address = a_address;
         IncludePhoto = a_includePhoto;
         CorrespondenceAddress = a_correspondenceAddress;
      }

      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Address { get; set; }
      public string CorrespondenceAddress { get; set; }
      public bool IncludePhoto { get; set; }

      public List<Person>   Find()
      {
         //Do something
         return new List<Person>();
      }
   }

   public class Person{}
}
