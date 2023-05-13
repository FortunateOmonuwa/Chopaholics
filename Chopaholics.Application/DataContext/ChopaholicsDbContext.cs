using Chopaholics.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopaholics.Application.DataContext
{
    public class ChopaholicsDbContext : DbContext
    {
        public ChopaholicsDbContext(DbContextOptions<ChopaholicsDbContext> options) : base(options)
        {
            
        }

        public DbSet<Chow> Chows { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Cart { get; set; }

    }
}
