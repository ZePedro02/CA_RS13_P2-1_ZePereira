using D00_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;

namespace CA_RS13_P2_1_ZePereira
{
    class Menu
    {

        #region Dependencies
        private readonly VacationService _vacationService;
        private readonly LoginService _loginService;
        private readonly ProfileService _profileService;
        #endregion

        #region Constructors
        public Menu(VacationService vacationService, LoginService loginService, ProfileService profileService)
        {
            _vacationService = vacationService;
            _loginService = loginService;
            _profileService = profileService;
        }
        #endregion

        #region Methods

        public Person ShowLoginMenu()
        {
            Utility.WriteTitle("Login", "", "");
            Utility.WriteInfoMessage("Se pretende sair prima 'ESC'","","\n");
            Person loggedPerson = null;

            while (loggedPerson == null)
            {

                string username = Utility.EscExitLogginForm("Username: ");
               
                string password = Utility.EscExitLogginForm("Password: ");

                loggedPerson = _loginService.Authentication(username, password);


                if (loggedPerson == null)
                {
                    Utility.WriteErrorMessage("Utilizador inválido, tente novamente.", "", "\n\n");
                }
            }
            Utility.WriteInfoMessage($"Loggin efetuado com sucesso! Bem-vindo {loggedPerson.Username}", "\n", "\n");
            return loggedPerson;
        }

      

        public void ShowMainMenu(Person loggedPerson)
        {
            string role = loggedPerson.GetRole();
            bool exit = false;
            if (role == "Collaborator")
            {
                while (!exit)
                {
                    ShowCollabMainMenu();
                    exit = MenuCollabHandler(loggedPerson);
                }
            }
            else
            {
                while (!exit)
                {
                    ShowAdminMainMenu();
                    exit = MenuAdminHandler();
                }
                

            }
        }

        private bool MenuCollabHandler(Person loggedPerson)
        {
            int input = Utility.ValidateInt("opção pretendida");
            switch (input)
            {

                case 1:
                    //Adicionar
                    Utility.WriteTitle("Adicionar férias");
                    DateTime beginDate = Utility.ValidateDate("data de início das férias");

                    DateTime endDate = Utility.ValidateDate("data de fim das férias");

                    _vacationService.AddVacation(beginDate, endDate, loggedPerson.Username);

                    return false;
                case 2:
                    //Consultar
                    DateTime beginDateConsult = Utility.ValidateDate("Data de: ");

                    DateTime endDateConsult = Utility.ValidateDate("Até: ");

                    _vacationService.ConsultVacations(beginDateConsult, endDateConsult, loggedPerson.Username);
                    return false;

                case 3:
                    //Listar
                    Utility.WriteTitle("Listar férias");
                    Utility.WriteMessage("");
                    _vacationService.ListVacation(loggedPerson.Username);
                    return false;
                case 4:
                    //Editar
                    _vacationService.UpdateVacation(loggedPerson.Username);
                    return false;
                case 5:
                    //Editar perfil
                    EditProfileMenu(loggedPerson);
                    return false;
                case 6:
                    //Logout
                    Utility.WriteInfoMessage("Logout successful", "\n", "\n\n");
                    return true;
                default:
                    Utility.WriteErrorMessage("Opção inválida!", "\n", "\n\n");
                    return false;
            }
        }
        


        private void EditProfileMenu(Person loggedPerson)
        {
            bool exitEditCollab = false;
            while (!exitEditCollab)
            {
                ShowEditCollabMenu();
                exitEditCollab = MenuEditCollabHandler(loggedPerson);
            }
        }

        private bool MenuEditCollabHandler(Person loggedPerson)
        {
            bool exit = false;
            int input = Utility.ValidateInt("a opção: ");
            switch (input)
            {
                case 1:
                    //Edit Username
                    Utility.WriteInfoMessage("Insira o novo Username: ");
                    string newUserName = Console.ReadLine();
                    string oldUserName = loggedPerson.Username;
                    
                    _profileService.EditUserName(newUserName, loggedPerson);
                    _vacationService.UpdateVacationsWithNewUserName(oldUserName, newUserName);
                    return exit = false;

                case 2:
                    //Edit password
                    Utility.WriteInfoMessage("Insira o nova Password: ");
                    string newPassword = Utility.ReadPassword();
                    _profileService.EditPassword(newPassword, loggedPerson);
                    return exit = false;
                case 3:
                    //Sair
                    return exit = true;
                default:
                    return exit = false;
            }

        }

        public  bool MenuAdminHandler()
        {
            int input = Utility.ValidateInt(" a opção pretendida");
            switch (input)
            {
                case 1:
                    //adicionar férias

                    Utility.WriteTitle("Adicionar férias");

                    Utility.WriteMessage("Utilizador: ");
                    string usernameAddVacation = Console.ReadLine();
                    if (_profileService.IsUserNameInUse(usernameAddVacation))
                    {
                        DateTime beginDate = Utility.ValidateDate("data de início das férias");

                        DateTime endDate = Utility.ValidateDate("data de fim das férias");

                        _vacationService.AddVacation(beginDate, endDate, usernameAddVacation);
                    }
                    else
                    {
                        Utility.WriteErrorMessage("O utilizador não existe.", "\n", "\n");
                    }
                    Console.Clear();
                    return false;
                case 2:
                    //consultar férias
                    Utility.WriteMessage("Utilizador: ");
                    string usernameSerachVacation = Console.ReadLine();
                    if (_profileService.IsUserNameInUse(usernameSerachVacation))
                    { 
                        DateTime beginDateConsult = Utility.ValidateDate("Data de: ");

                        DateTime endDateConsult = Utility.ValidateDate("Até: ");

                        _vacationService.ConsultVacations(beginDateConsult, endDateConsult, usernameSerachVacation);
                    }
                    else
                    {
                        Utility.WriteErrorMessage("O utilizador não existe.", "\n", "\n");
                    }
                    Console.Clear();
                    return false;

                case 3:
                    //listar férias
                    _vacationService.ListVacationAdmin();
                    return false;
                case 4:
                    //editar férias
                    Utility.WriteMessage("Utilizador: ");
                    string usernameEditVacation = Console.ReadLine();

                    if (_profileService.IsUserNameInUse(usernameEditVacation))
                    {
                        _vacationService.UpdateVacation(usernameEditVacation);
                    }
                    else
                    {
                        Utility.WriteErrorMessage("O utilizador não existe.", "\n", "\n");
                    }

                    Console.Clear();
                    return false;
                case 5:
                    //adicionar pessoa
                    Utility.WriteMessage("Utilizador: ");
                    string usernameCreateUser = Console.ReadLine();

                    if (!_profileService.IsUserNameInUse(usernameCreateUser))
                    {
                        int inputCreateUser = Utility.ValidateInt(" a opção que pretende adicionar:\n1. Colaborador(a)\n2. Aministrador(a)");
                        if (inputCreateUser < 1 || inputCreateUser > 2) Utility.WriteErrorMessage("Não inseriu uma opção válida");
                        else
                        {
                            string role = string.Empty;
                            if (inputCreateUser == 1) role = "Collaborator";
                            if (inputCreateUser == 2) role = "Admin";
                            string newUserPassword = Utility.ReadPassword();
                            _loginService.CreateUser(usernameCreateUser, newUserPassword,role);
                        }
                    }
                    else
                    {
                        Utility.WriteErrorMessage("O utilizador Já existe.", "\n", "\n");
                    }

                    Console.Clear();
                    return false;
                case 6:
                    
                    //editar pessoa

                    Utility.WriteMessage("Utilizador: ");
                    string usernameEditProfile = Console.ReadLine();

                    if (_profileService.IsUserNameInUse(usernameEditProfile))
                    {
                        var userList = _loginService.GetPeople();
                        foreach(var person in userList) 

                            if (person.Username == usernameEditProfile)
                                EditProfileMenu(person);

                    }
                    else
                    {
                        Utility.WriteErrorMessage("O utilizador não existe.", "\n", "\n");
                    }

                    Console.Clear();
                    return false;
                case 7:
                    //logout
                    Utility.WriteInfoMessage("Logout bem-sucedido!\nPrima qualquer tecla para voltar ao menu anterior.");
                    Console.ReadKey();
                    Console.Clear();
                    return true;
                default: 
                    return true;
            }


        }

        public static void ShowAdminMainMenu()
        {
            Utility.WriteInfoMessage("1. Adicionar férias", "", "\n");
            Utility.WriteInfoMessage("2. Consultar férias", "", "\n");
            Utility.WriteInfoMessage("3. Listar férias", "", "\n");
            Utility.WriteInfoMessage("4. Editar férias", "", "\n");
            Utility.WriteInfoMessage("5. Ádicionar pessoa", "", "\n");
            Utility.WriteInfoMessage("6. Editar pessoa", "", "\n");
            Utility.WriteInfoMessage("7. Logout", "", "\n");
        }

        public static void ShowCollabMainMenu()
        {
            Utility.WriteTitle("Menu Principal", "\n\n");

            Utility.WriteInfoMessage("1. Adicionar férias", "", "\n");
            Utility.WriteInfoMessage("2. Consultar férias", "", "\n");
            Utility.WriteInfoMessage("3. Listar férias", "", "\n");
            Utility.WriteInfoMessage("4. Editar férias", "", "\n");
            Utility.WriteInfoMessage("5. Editar perfil", "", "\n");
            Utility.WriteInfoMessage("6. Logout", "", "\n");
        }


        public static void ShowEditCollabMenu()
        {
            Utility.WriteInfoMessage("1. Editar username", "\n", "\n");
            Utility.WriteInfoMessage("2. Editar Password", "", "\n");
            Utility.WriteInfoMessage("3. Sair", "", "\n");
        }

        
        #endregion

    }
}
