using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement
{
    class MovieContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=MovieManagement_EFCore;MultipleActiveResultSets=true;Trusted_connection=true;Integrated Security=true");
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
