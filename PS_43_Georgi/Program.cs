using DataLayer.Database;
using DataLayer.Model;
using Welcome.Others;

using (var context = new DatabaseContext())
{
    context.Database.EnsureCreated();
    context.Add<DatabaseUser>(new DatabaseUser()
    {
        Name = "user",
        Password = "password",
        Expires = DateTime.Now,
        Role = UserRolesEnum.STUDENT,
        Email = "user@gmail.com",
        date = "20.03.2024"
    });
    context.SaveChanges();
    var users = context.Users.ToList();
    
    Console.WriteLine("Въведете потребителско име:");
    string userName = Console.ReadLine();
    Console.WriteLine("Въведете парола:");
    string password = Console.ReadLine();

    bool isValidUser = users.Any(user => user.Name == userName && user.Password == password);

    if (isValidUser)
    {
        Console.WriteLine("Валиден потребител");
    }
    else
    {
        Console.WriteLine("Невалидни данни");
    }
    Console.ReadKey();
    
}
