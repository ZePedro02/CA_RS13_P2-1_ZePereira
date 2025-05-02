using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;
namespace CA_RS13_P2_1_ZePereira
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility.SetUniCode();
            Utility.WriteTitle("Login","","");
            
            var loginService = new LoginService();
            VacationService vacationService = new VacationService();
            Person loggedPerson = null;

            while (loggedPerson == null)
            {
                Utility.WriteMessage("Username: ");
                string username = Console.ReadLine();


                Utility.WriteMessage("Password: ");
                string password = Console.ReadLine();

                loggedPerson = loginService.Authentication(username, password);


                if (loggedPerson == null)
                {
                    Utility.WriteErrorMessage("Utilizador inválido, tente novamente.","","\n\n");
                }
            }
            Utility.WriteInfoMessage($"Loggin efetuado com sucesso! Bem-vindo {loggedPerson.Username}","\n");

          
            /*        ADICIONAR FÉRIAS
                Utility.WriteTitle("Adioconar férias");

                Utility.WriteMessage("Insira a data de início das férias: ");
                DateTime beginDate = Convert.ToDateTime(Console.ReadLine());


                Utility.WriteMessage("Insira a data de fim das férias: ");
                DateTime endDate = Convert.ToDateTime(Console.ReadLine());


                vacationService.AddVacation(beginDate, endDate, loggedPerson.Username);
            */
            Utility.TerminateConsole();
        }
    }
}
