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
            VacationService vacationService = new VacationService();
            LoginService loginService = new LoginService();
            ProfileService profileService = new ProfileService(loginService.GetPeople());

            Menu menu = new Menu(vacationService, loginService, profileService);
            //Person loggedPerson = menu.ShowLoginMenu();

            //menu.ShowMainMenu(loggedPerson);

            while (true)
            {
                Person loggedPerson = menu.ShowLoginMenu();

                menu.ShowMainMenu(loggedPerson);
            } 



            //    vacationService.ListVacation(loggedPerson.Username);
            
            Utility.TerminateConsole();
        }
    }
}
