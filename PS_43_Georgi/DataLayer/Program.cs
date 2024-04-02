using DataLayer.Database;
using DataLayer.Model;
using System;

namespace DataLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DatabaseContext())
            {
                context.Database.EnsureCreated();
                var logger = new Logger(context);
                logger.Log("Приложението е стартирано.");

                while (true)
                {
                    Console.WriteLine("\n1. Списък с потребители");
                    Console.WriteLine("2. Добави нов потребител");
                    Console.WriteLine("3. Изтрий потребител");
                    Console.WriteLine("4. Изход");
                    Console.Write("Изберете опция: ");
                    var option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            ListUsers(context);
                            break;
                        case "2":
                            AddUser(context, logger);
                            break;
                        case "3":
                            DeleteUser(context, logger);
                            break;
                        case "4":
                            return;
                        default:
                            Console.WriteLine("Невалидна опция.");
                            break;
                    }
                }
            }
        }

        static void ListUsers(DatabaseContext context)
        {
            var users = context.Users.ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"Име: {user.Name}, Парола: {user.Password}");
            }
        }

        static void AddUser(DatabaseContext context, Logger logger)
        {
            Console.Write("Въведете потребителско име: ");
            string userName = Console.ReadLine();
            Console.Write("Въведете парола: ");
            string password = Console.ReadLine();

            var newUser = new DatabaseUser
            {
                Name = userName,
                Password = password,
                Expires = DateTime.Now.AddYears(1) // Or any other logic for expiration
            };

            context.Users.Add(newUser);
            context.SaveChanges();
            logger.Log($"Добавен е нов потребител: {userName}");
            Console.WriteLine("Потребителят е добавен успешно.");
        }

        static void DeleteUser(DatabaseContext context, Logger logger)
        {
            Console.Write("Въведете име на потребителя за изтриване: ");
            string userName = Console.ReadLine();

            var userToDelete = context.Users.FirstOrDefault(user => user.Name == userName);
            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);
                context.SaveChanges();
                logger.Log($"Потребител изтрит: {userName}");
                Console.WriteLine("Потребителят е изтрит успешно.");
            }
            else
            {
                Console.WriteLine("Потребител не е намерен.");
            }
        }
    }
}
