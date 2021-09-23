using DiaryInWpf.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryInWpf.Models.Configurations
{
    class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            ToTable("dbo.Groups");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
