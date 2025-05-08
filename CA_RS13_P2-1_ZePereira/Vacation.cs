using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_RS13_P2_1_ZePereira
{

    public enum VacationState {Pending, Approved, Rejected }
    public class Vacation
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Username { get; set; }
        public VacationState State { get; set; }

        #region Constructors
        public Vacation(DateTime beginDate, DateTime endDate, string username)
        {
            BeginDate = beginDate;
            EndDate = endDate;
            Username = username;
            State = VacationState.Pending;
        }


        #endregion

    }
}
