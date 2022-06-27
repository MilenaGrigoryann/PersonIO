using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePersonService
{
    public class PersonService
    {
        private readonly string path = @"People";      
        public PersonService()
        {
            path = Path.Combine(path,".txt");
        }
        public void Create(Person person)
        {
            string[] personstr = new string[4];
            personstr[0] = person.Id.ToString();
            personstr[1] = person.Age.ToString();
            personstr[2] = person.LastName;
            personstr[3] = person.FirstName;
            File.AppendAllLines(path, personstr);
        }
        public List<Person> ConvertToPerson(string[] people)
        {
            List<Person> list = new List<Person>();           
            for (int i = 0; i < people.Length; i=i+4)
            {
                list.Add(new Person()
                {
                    Id = Guid.Parse(people[i]),
                    Age = Convert.ToInt32(people[i + 1]),
                    LastName = people[i + 2],
                    FirstName = people[i + 3]
                });

            }
            return list;
        }
        public string[] Read()
        {
            string[] people = File.ReadAllLines(path);         
            return people;
        }
        public void Print(List<Person> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Id},{person.Age},{person.FirstName},{person.LastName}");
            }

        }
    }
}
