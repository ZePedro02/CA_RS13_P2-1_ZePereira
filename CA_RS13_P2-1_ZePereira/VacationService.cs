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
            if (!IsEndDateAfterBeginDate(endDate, beginDate))
            {
                Utility.WriteErrorMessage("Data de fim não pode ser antes da data de início!");
                return false;
            }

            if (!IsEndDateAfterToday(endDate) || !IsBeginDateAfterToday(beginDate))
            {
                Utility.WriteErrorMessage("Inseriu uma data antes do dia de hoje!");
                return false;
            }

            if (IsVacationOverlap(vacations, beginDate, endDate, username))
            {
                Utility.WriteErrorMessage("O utilizador já tem férias marcadas nessa data!");
                return false;
            }

            vacations.Add(new Vacation(beginDate, endDate, username));
                Utility.WriteMessage("Pedido adicionado com sucesso!", "\n", "\n\n\n"); 
            return true;
        }

        public bool IsEndDateAfterBeginDate(DateTime endDate, DateTime beginDate)
        {
            if (endDate >= beginDate)
                return true;

            return false;
        }
        public bool IsBeginDateAfterToday(DateTime beginDate)
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



        public void ListVacation(string username)
        {

            var personVacation = vacations.Where(v => v.Username == username).OrderBy(v => v.BeginDate).ToList();
            Utility.WriteInfoMessage($"{"Begin Date", -5} - End Date","\n","\n\n");
            foreach (var vacation in personVacation)
            {
                Utility.WriteMessage($"{vacation.BeginDate.ToShortDateString(), -5} {vacation.EndDate.ToShortDateString()}", "","\n");
            }

        }

        public List<Vacation> ListAllVacation(string username)
        {
            var personVacation = vacations
                .Where(v => v.Username == username && v.BeginDate > DateTime.Today)
                .OrderBy(v => v.BeginDate)
                .ToList();

            if (!CheckIfThereAreVacationsAvailable(personVacation))
                return personVacation;

            WriteListToConsole(personVacation);

            return personVacation;
        }

        private static void WriteListToConsole(List<Vacation> personVacation)
        {
            Utility.WriteInfoMessage($"{"Username",-5} - {"Begin Date",-5} - {"End Date",-5}  ", "\n", "\n\n");


            for (int i = 0; i < personVacation.Count; i++)
            {
                Utility.WriteMessage($"{i + 1}. {personVacation[i].Username,-5} {personVacation[i].BeginDate.ToShortDateString(),-5} {personVacation[i].EndDate.ToShortDateString()}", "", "\n");

            }
        }

        public void ConsultVacations(DateTime beginDate, DateTime endDate, string username)
        {
            var personVacation = vacations
                .Where(v => v.BeginDate >= beginDate && v.EndDate <= endDate && v.Username == username)
                .OrderBy(v => v.BeginDate)
                .ToList();
            
            if (!CheckIfThereAreVacationsAvailable(personVacation))
                return;
            
            Utility.WriteInfoMessage($"{"Username",-5} - {"Begin Date",-5} - {"End Date", -5}  ", "\n", "\n\n");
            foreach (var vacation in personVacation)
            {
                Utility.WriteMessage($"{vacation.Username, -5} {vacation.BeginDate.ToShortDateString(),-5} {vacation.EndDate.ToShortDateString()}", "", "\n");
            }
        }

        public void UpdateVacationsWithNewUserName(string oldUsername, string newUserName)
        { 
            var oldUserVacations = vacations
                .Where(v => v.Username == oldUsername)
                .ToList();

            foreach (var vacation in oldUserVacations)
                vacation.Username = newUserName;

            Utility.WriteInfoMessage($"Foram alterados {oldUserVacations.Count} registos!","\n");
        
        }

        public void UpdateVacation(string username)
        {
            var vacationsAfterToday = ListAllVacation(username);

            int input= ReadListOption(vacationsAfterToday);

            DateTime newBeginDate = Utility.ValidateDate(" a nova data de início das férias");
            DateTime newEndDate = Utility.ValidateDate(" a nova data de fim das férias");

            if (IsVacationOverlap(vacationsAfterToday, newBeginDate, newEndDate, username))
            {
                Utility.WriteErrorMessage("O utilizador já tem férias marcadas nessa data!", "\n\n");
                return;
            }

            vacationsAfterToday[input - 1].BeginDate = newBeginDate;
            vacationsAfterToday[input - 1].BeginDate = newEndDate;
            vacationsAfterToday[input - 1].State = VacationState.Pending;

            Utility.WriteMessage("As datas foram aletradas com sucesso!");

        }

        private static int ReadListOption(List<Vacation> vacationsAfterToday)
        {
            var input = Utility.ValidateInt("o índice que pretende editar");
            if (input > vacationsAfterToday.Count + 1 || input < 1)
            {
                Utility.WriteErrorMessage("O valor que inseriu não é uma opção da lista");              
            }
            return input;
        }

        public bool CheckIfThereAreVacationsAvailable(List<Vacation> vacations)
        {
            if (vacations.Count == 0)
            {
                Utility.WriteInfoMessage($"Não há férias marcadas para o futuro.");
                return false;
            }
            return true;
        }

        public void ValidateVacationsAdmin(List<Person> persons)
        {
            var usernames = persons
                .Select(v => v.Username)
                .ToList();
            
            var pendingVacations = vacations
                .Where(j => j.State == VacationState.Pending && usernames.Contains(j.Username))
                .ToList();

            if (!CheckIfThereAreVacationsAvailable(pendingVacations))
                return;

            WriteListToConsole(pendingVacations);

            int inputIndex = ReadListOption(pendingVacations);

            int inputOption = Utility.ValidateInt(" a opção que pretende\n\n1. Aprovar\n2. Rejeitar\n3. Cancelar\n");

            switch (inputOption)
            {
                case 1:
                    pendingVacations[inputIndex - 1].State = VacationState.Approved;
                    Utility.WriteInfoMessage("Férias aprovadas!");
                    break;
                case 2:
                    pendingVacations[inputIndex - 1].State = VacationState.Rejected;
                    Utility.WriteInfoMessage("Férias rejeitadas!");
                    break;
                default:
                    Utility.WriteInfoMessage("Operação cancelada");
                    break;
            }
            }

    }
}
