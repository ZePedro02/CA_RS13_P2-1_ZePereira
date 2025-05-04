using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace D00_Utility
{
    public class Utility
    {

        public static void WriteTitle( string title,string beginTitle="\n\n\n", string endTitle="\n")
        {
            /*
              Console.Write("\n---------------------------------");
                Console.Write("\n-------Matriz------");
                Console.Write("\n---------------------------------\n\n\n");
            */

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{beginTitle}{new string('-', 50)}");

            Console.WriteLine(title.ToUpper());

            Console.WriteLine($"{new string('-', 50)}{endTitle}");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void SetUniCode()
        {
         //  Console.WriteLine("á Á à À ã Ã â Â ç Ç º ª");
            Console.OutputEncoding = Encoding.UTF8;
           // Console.WriteLine("á Á à À ã Ã â Â ç Ç º ª");
        }

        public static void WriteMessage(string message, string beginMessage = "", string endMessage = "")
        {
            Console.Write($"{beginMessage}{message}{endMessage}");
        }
        public static void WriteErrorMessage(string message, string beginMessage = "", string endMessage = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{beginMessage}{message}{endMessage}");
            Console.ForegroundColor = ConsoleColor.White;
        }

     
        public static void WriteInfoMessage(string message, string beginMessage = "", string endMessage = "")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{beginMessage}{message}{endMessage}");
            Console.ForegroundColor = ConsoleColor.White;
        }


        public static void TerminateConsole()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("\n\nPrima qualquer tecla para terminar.");

            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }

        public static void PauseConsole()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("\n\nPrima qualquer tecla para continuar.");

            Console.ForegroundColor = ConsoleColor.White;

            Console.ReadKey();
        }

        /*  public bool ValidarDouble(string input)
          {
              bool valDouble = true;
              if (!Double.TryParse(input))
                  Utility.WriteErrorMessage("Valor inválido!");
              else
              {
                  return valDouble;
              }
          }
        */
        public static int ValidateInt(string text)
        {
            int id;
            while (true)
            {
                WriteMessage($"Inserir {text}: ", "");
                string input = Console.ReadLine();
                if (int.TryParse(input, out id))
                {
                    return id;
                }
                else
                {
                    WriteErrorMessage("Insira um número inteiro!", "\n","\n");
                }

            }
        }
        public static DateTime ValidateDate(string text)
        {
            DateTime Date;
            while (true)
            {
                WriteMessage($"{text} : ", "");
                string input = Console.ReadLine();
                if (DateTime.TryParse(input, out Date))
                {
                    return Date;
                }
                else
                {
                    WriteErrorMessage("Formato de data incorreto! (dd/mm/yyyy)", "\n","\n");
                }

            }
        }
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {

                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }
            while (key.Key != ConsoleKey.Enter);

            return password;
        }
    }
}
