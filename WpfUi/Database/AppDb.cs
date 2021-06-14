using Demo.Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Database
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(
        //    DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=myData123;Integrated Security=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
