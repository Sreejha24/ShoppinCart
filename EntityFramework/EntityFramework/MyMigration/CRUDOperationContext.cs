using EntityFramework.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EntityFramework.MyMigration
{
    public class CRUDOperationContext : DbContext
    {
        private string connectionstring;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            connectionstring = "Data Source=192.168.50.95;Initial Catalog=sprathipati;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";
            optionsBuilder.UseSqlServer(connectionstring);
            //base.OnConfiguring(optionsBuilder);//To build the connectionstring
        }

        public DbSet<Person21> persons { get; set; }
        public DbSet<Job21> jobs { get; set; }
    }
}
