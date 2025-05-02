using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS13_P2_1_ZePereira
{
    public abstract class Person
    {
        #region Properties
            public  string Username { get; set; }
            public  string  Password { get; set; }
        #endregion

        #region Constructors
        protected Person(string username, string password)
        {
            Username = username;
            Password = password;
        }
        protected Person()
        {
            Username = "TempUsername";
            Password = "TempPassword";
        }
        #endregion

        #region Methods
        public abstract string GetRole();
        #endregion



    }
}
