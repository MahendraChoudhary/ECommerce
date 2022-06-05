using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.TestClient
{
    internal class MenuBuilder
    {
        public class Home
        {
            private static List<Menu> menus = new List<Menu>
            {
                new Menu{Code=1, Name= "Register"},
                new Menu{Code=2, Name= "Login"}
            };

            public static void Display()
            {
                menus.ForEach(m => Console.WriteLine($"{m.Code}: {m.Name}"));
            }

            private static void Register()
            {
                AuthenticationUtility.Register();
                Display();
                ProcessCommand(int.Parse(Console.ReadLine()));
            }

            private static void Login()
            {
                Console.WriteLine("Enter username");
                var userName = Console.ReadLine();
                Console.WriteLine("Enter password");
                var password = Console.ReadLine();
                if (!AuthenticationUtility.Login(userName, password))
                    Display();
            }

            public static void ProcessCommand(int code)
            {
                switch (code)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    default:
                        Console.WriteLine("Not supported option");
                        Display();
                        ProcessCommand(int.Parse(Console.ReadLine()));
                        break;
                }
            }
        }

    }

    internal class Menu
    {
        public int Code { get; set; }

        public string Name { get; set; }
    }
}
