using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace ZXCStudentsInfo.Classes
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Students> Students { get; set; } = null!;
        public DbSet<Specialnost> Specialnosts { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try { optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-1NMG4AP\SQLEXPRESS;Initial Catalog=ZXCInfStudents;Integrated Security=True;"); }
            catch { optionsBuilder.UseSqlServer(@"Data Source=44-6\SQLEXPRESS01;Initial Catalog=ZXCInfStudents;Integrated Security=True;"); }

            
        }
    }
}
