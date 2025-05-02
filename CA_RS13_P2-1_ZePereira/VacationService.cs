using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;
namespace CA_RS13_P2_1_ZePereira
{
    public class VacationService
    {

        private List<Vacation> vacations = new List<Vacation>();

        public bool AddVacation(DateTime beginDate, DateTime endDate, string username)
        {
            if(!IsEndDateAfterBeginDate(endDate, beginDate))
            {
                Utility.WriteErrorMessage("Data de fim não pode ser antes da data de início!");
                return false;
            }

            if(!IsEndDateAfterToday(endDate) || !IsBeginDateAfterToday(beginDate))
            {
                Utility.WriteErrorMessage("Inseriu uma data antes do dia de hoje!");
                return false;
            }

            if(IsVacationOverlap(vacations, beginDate, endDate, username))
            {
                Utility.WriteErrorMessage("O utilizador já tem férias marcadas nessa data!");
                return false;
            }

            vacations.Add(new Vacation(beginDate, endDate, username));
            return true;
        }

        public bool IsEndDateAfterBeginDate(DateTime endDate, DateTime beginDate )
        {
            if (endDate >= beginDate) 
                return true;
            
            return false;   
        }
        public bool IsBeginDateAfterToday( DateTime beginDate)
        {
            if (beginDate >= DateTime.Today)
                return true;

            return false;
        }

        public bool IsEndDateAfterToday(DateTime endDate)
        {
            if (endDate >= DateTime.Today)
                return true;

            return false;
        }

        public bool IsVacationOverlap(List<Vacation> vacations, DateTime beginDate, DateTime endDate, string username)
        {
            var overlap = vacations.Any(v => v.Username == username && !(v.BeginDate > endDate || v.EndDate < beginDate));

            if (overlap)
                return true;
            
            return false;

        }
    }
}
