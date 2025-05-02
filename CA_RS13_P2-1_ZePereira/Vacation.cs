using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS13_P2_1_ZePereira
{
    public class Vacation
    {

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Username { get; set; }

        #region Constructors

        public Vacation()
        { 
            BeginDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
            Username = string.Empty;
        }

        public Vacation(DateTime beginDate, DateTime endDate, string username)
        {
            BeginDate = beginDate;
            EndDate = endDate;
            Username = username;
        }


        #endregion

    }
}
