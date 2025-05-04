using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;


namespace CA_RS13_P2_1_ZePereira
{
    public class LoginService
    {

        private List<Person> persons;
        public LoginService()
        {
            persons = new List<Person>()
            {
                new Admin("Admin1","Admin1"),
                new Collaborator("Col01","Col01"),
                new Collaborator("Col02","Col02")
            };
        }

        public Person Authentication(string username, string password)
        {

            return persons.FirstOrDefault(p => p.Username == username && p.Password == password);

        }

        public List<Person> GetPeople()
        {
            return persons;
        }
       
    }
}
