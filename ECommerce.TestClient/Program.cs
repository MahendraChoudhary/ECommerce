// See https://aka.ms/new-console-template for more information
using ECommerce.TestClient;

Console.WriteLine("Hello, World!");

MenuBuilder.Home.Display();
MenuBuilder.Home.ProcessCommand(int.Parse(Console.ReadLine()));

Console.ReadLine();