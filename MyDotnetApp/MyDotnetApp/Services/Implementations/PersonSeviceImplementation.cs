using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDotnetApp.Models;

namespace MyDotnetApp.Services.Implementations
{
    public class PersonSeviceImplementation : IPersonService
    {
        public Person Create(Person person)
        {
            return person;
            //throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            Console.WriteLine($"Deleting person with id {id}");
            //throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
           List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
            //throw new NotImplementedException();
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = i,
                FirstName = $"FirstName {i}",
                LastName = $"LastName {i}",
                Address = $"Address {i}",
                Gender = i % 2 == 0 ? "Male" : "Female"
            };
        }

        public Person FindById(long id)
        {
            return new Person
            {
                
                Id = id,
                FirstName = "Gabriel",
                LastName = "Inácio",
                Address = "Rua 1",
                Gender = "Male"
            };
            //throw new NotImplementedException();
        }

        public Person Update(Person person)
        {
            return person;
            //throw new NotImplementedException();
        }
    
        
    }
}