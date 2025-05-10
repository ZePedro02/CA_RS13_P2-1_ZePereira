using D00_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS13_P2_1_ZePereira
{
    internal class ProfileService
    {

        #region Dependencies
        private readonly List<Person> _persons;
        #endregion

        #region Constructor
        public ProfileService(List<Person> persons)
        {
            _persons = persons;
        }
        #endregion

        #region Methods

        public bool IsUserNameInUse(string newUsername)
        { 
        if (_persons.Any(p => p.Username == newUsername)) { return true; } return false;
        }

        public bool EditUserName(string newUsername, Person loggedPerson)
        { 

            if (IsUserNameInUse(newUsername)) 
            {
                Utility.WriteErrorMessage("Username já existe!", "\n", "\n");
                return false;
            }
            else
            { 
                Utility.WriteInfoMessage($"Username alterado de {loggedPerson.Username} para {newUsername}!", "\n", "\n");
                
                loggedPerson.Username = newUsername;
                
                return true;
            }  
        }
        public bool EditPassword(string newPassword, Person loggedPerson)
        {
                Utility.WriteInfoMessage("Password alterada!", "\n", "\n");
                loggedPerson.Password = newPassword;
                return true;           
        }



        #endregion

    }
}
