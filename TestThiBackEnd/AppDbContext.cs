using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestThiBackEnd.Models;

namespace TestThiBackEnd
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
