using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManUsers();
            Console.WriteLine("Hello World!");
        }
        public static void ManUsers()
        {
            var users = GetUsers(100);

            foreach (var user in users)
            {
                if (user.id > 100)
                {
                    break;
                }
                Console.WriteLine($"ID:{user.id},Name:{user.Name}");
            }

        }

        public static IEnumerable<User> GetUsers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new User { id = i, Name = $"Name{i}" };
            }
        }
    }

}
