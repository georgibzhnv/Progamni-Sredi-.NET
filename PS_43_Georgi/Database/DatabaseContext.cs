using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Welcome.Others;

namespace DataLayer.Database
{
    class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFinder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welcome.db";
            string databasePath = Path.Combine(solutionFinder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e => e.Id).ValueGeneratedOnAdd();

            var user = new DatabaseUser
            {
                Id = 1,
                Name = "John Doe",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10),
                Email = "john@gmail.com",
                date = "10.03.2024"
            };

            var user2 = new DatabaseUser
            {
                Id = 2,
                Name = "Johnny Test",
                Password = "5555",
                Role = UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(5),
                Email = "test@gmail.com",
                date = "11.03.2024"
            };

            var user3 = new DatabaseUser
            {
                Id = 3,
                Name = "Jude Bellingham",
                Password = "1212",
                Role = UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(20),
                Email = "jude@gmail.com",
                date = "11.03.2024"
            };

            modelBuilder.Entity<DatabaseUser>()
                .HasData(user);
        }

            public DbSet<DatabaseUser> Users {  get; set; }
        }
    }

