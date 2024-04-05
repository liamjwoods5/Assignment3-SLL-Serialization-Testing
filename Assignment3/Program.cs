using Assignment3.Utility;
using System;
namespace Assignment3
{
    internal class Program
    {
        //summary comments at the top of ILinkedListADT.cs
        public static void Main(string[] args)
        {
            SLL linkedList = new SLL();

            while (true)
            {
                Console.WriteLine("Enter user details or 'q' to quit:");

                Console.Write("Id: ");
                string idInput = Console.ReadLine();
                if (idInput.ToLower() == "q") break;
                int id = int.Parse(idInput);

                Console.Write("Name: ");
                string name = Console.ReadLine();
                if (name.ToLower() == "q") break;

                Console.Write("Email: ");
                string email = Console.ReadLine();
                if (email.ToLower() == "q") break;

                Console.Write("Password: ");
                string password = Console.ReadLine();
                if (password.ToLower() == "q") break;

                User user = new User(id, name, email, password);
                linkedList.AddLast(user);

                //linkedList.PrintAllUsers();
            }
        }
    }
}
