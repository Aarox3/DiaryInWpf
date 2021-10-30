
namespace DiaryInWpf
{
    using DiaryInWpf.Models.Configurations;
    using DiaryInWpf.Models.Domains;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;

    public class ApplicationDbContext : DbContext
    {
      

            public DbSet<Student> Students { get; set; }

            public DbSet<Group> Groups { get; set; }

            public DbSet<Rating> Ratings { get; set; }


           protected override void OnModelCreating(ModuleBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true);

            var config = builder.Build();

            optionsBuilder
                .UseSqlServer(config["ConnectionString"]);
        }
    }
    }


