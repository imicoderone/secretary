using Microsoft.EntityFrameworkCore;
using Secretary.Domain;
using System;

namespace Secretary.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        public DbSet<Recognition> Recognitions { get; set; }
    }
}
