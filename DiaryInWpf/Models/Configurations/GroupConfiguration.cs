using DiaryInWpf.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiaryInWpf.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DiaryInWpf.Models.Configurations
{
    class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        class GroupConfiguration : IEntityTypeConfiguration<Group>
        {
            public void Configure(EntityTypeBuilder<Group> builder)
            {
                builder.ToTable("dbo.Groups");

                builder.Property(x => x.Id)
                    .ValueGeneratedOnAdd();

                builder.Property(x => x.Name)
                    .HasMaxLength(20)
                    .IsRequired();
            }
        }
    }
}

