using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement
{
    class UniversityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=StudentManagement_EFCore;MultipleActiveResultSets=true;Trusted_connection=true;Integrated Security=true");
        }
        public DbSet<Student> Students { get; set; }
    }
}
