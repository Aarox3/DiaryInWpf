using DiaryInWpf.Models.Domains;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryInWpf.Models.Configurations
{
    class StudentConfiguration : EntityTypeConfiguration<Student>
    {

        public StudentConfiguration()
        {
            ToTable("dbo.Students");

            HasKey(x => x.Id);
        }
    }
}
