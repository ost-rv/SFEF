using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFEF.Models;
using Microsoft.EntityFrameworkCore;

namespace SFEF
{
    public class SFEFContext : DbContext
    {
        // Объекты таблицы Authors
        public DbSet<Author> Authors { get; set; }

        // Объекты таблицы Books
        public DbSet<Book> Books { get; set; }

        // Объекты таблицы Genres
        public DbSet<Genre> Genres { get; set; }

        // Объекты таблицы Users
        public DbSet<User> Users { get; set; }

        public SFEFContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=K11WIN10VM;Database=EF;Trusted_Connection = true;");
        }
    }
}
