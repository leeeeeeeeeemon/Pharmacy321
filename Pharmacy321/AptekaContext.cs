using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace Pharmacy321
{
    public class AptekaContext : DbContext
    {
        public DbSet<Bills> Bills { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<Medication> Medication { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Order_History> Order_History { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<User> Users { get; set; } // Добавляем DbSet для таблицы Users

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=apteka;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>().HasKey(b => b.ID_Bills);
            modelBuilder.Entity<Category>().HasKey(c => c.ID_Category);
            modelBuilder.Entity<Client>().HasKey(c => c.ID_Client);
            modelBuilder.Entity<Contract>().HasKey(c => c.ID_Contract);
            modelBuilder.Entity<Employee>().HasKey(e => e.ID_Employee);
            modelBuilder.Entity<Materials>().HasKey(m => m.ID_Materials);
            modelBuilder.Entity<Medication>().HasKey(m => m.ID_Medication);
            modelBuilder.Entity<Order>().HasKey(o => o.ID_Order);
            modelBuilder.Entity<Order_History>().HasKey(oh => oh.ID_History);
            modelBuilder.Entity<Position>().HasKey(p => p.ID_Position);
            modelBuilder.Entity<Provider>().HasKey(p => p.ID_Provider);
            modelBuilder.Entity<Registration>().HasKey(r => r.ID_Registration);
            modelBuilder.Entity<Storage>().HasKey(s => s.ID_Storage);
            modelBuilder.Entity<User>().HasKey(u => u.ID_User); // Добавляем ключ для таблицы Users
        }
    }

    public class User
    {
        [Key]
        public int ID_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    public class Bills
    {
        [Key]
        public int ID_Bills { get; set; }
        public int ID_Contract { get; set; }
    }

    public class Category
    {
        [Key]
        public int ID_Category { get; set; }
        public string Name_Category { get; set; }
    }

    public class Client
    {
        [Key]
        public int ID_Client { get; set; }
        public string Name_Client { get; set; }
        public string Surname_Client { get; set; }
        public string LastName_Client { get; set; }
    }

    public class Contract
    {
        [Key]
        public int ID_Contract { get; set; }
        public int Contract_Number { get; set; }
    }

    public class Employee
    {
        [Key]
        public int ID_Employee { get; set; }
        public string Name_Employee { get; set; }
        public string Surname_Employee { get; set; }
        public string LastName_Employee { get; set; }
        public string Address_Employee { get; set; }
        public string Phone_Employee { get; set; }
        public string Email_Employee { get; set; }
        public int ID_Position { get; set; }
    }

    public class Materials
    {
        [Key]
        public int ID_Materials { get; set; }
        public string Name_Materials { get; set; }
        public DateTime Expire_Date { get; set; }
        public int Minimum_Balance { get; set; }
        public int ID_Storage { get; set; }
        public int ID_Employee { get; set; }
        public int ID_Category { get; set; }
    }

    public class Medication
    {
        [Key]
        public int ID_Medication { get; set; }
        public string Name_Medication { get; set; }
        public int Quantity_In_Stock { get; set; }
        public int Batch_Number { get; set; }
        public int Price_Medication { get; set; }
        public int? Social_Discount { get; set; }
    }

    public class Order
    {
        [Key]
        public int ID_Order { get; set; }
        public DateTime Order_Date { get; set; }
        public DateTime Shipment_Date { get; set; }
        public int ID_Provider { get; set; }
        public int ID_Medication { get; set; }
    }

    public class Order_History
    {
        [Key]
        public int ID_History { get; set; }
        public int ID_Client { get; set; }
        public int ID_Order { get; set; }
    }

    public class Position
    {
        [Key]
        public int ID_Position { get; set; }
        public string Name_Position { get; set; }
    }

    public class Provider
    {
        [Key]
        public int ID_Provider { get; set; }
        public string Name_Provider { get; set; }
        public string Address_Provider { get; set; }
        public string INN_Provider { get; set; }
        public string Enterprise_Classifier { get; set; }
        public string Phone_Provider { get; set; }
        public string Responsible_Person { get; set; }
        public string Work_Hours { get; set; }
    }

    public class Registration
    {
        [Key]
        public int ID_Registration { get; set; }
        public int ID_Client { get; set; }
        public int ID_Employee { get; set; }
        public int ID_Contract { get; set; }
    }

    public class Storage
    {
        [Key]
        public int ID_Storage { get; set; }
        public string Name_Storage { get; set; }
    }
}
