
namespace DiaryInWpf
{
    using DiaryInWpf.Models.Configurations;
    using DiaryInWpf.Models.Domains;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }


            public DbSet<Student> Students { get; set; }

            public DbSet<Group> Groups { get; set; }

            public DbSet<Rating> Ratings { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new StudentConfiguration());

                modelBuilder.Configurations.Add(new GroupConfiguration());

                modelBuilder.Configurations.Add(new RatingConfiguration());
            }

        }
    }


