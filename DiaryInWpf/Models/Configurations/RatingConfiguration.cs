using System.Data.Entity.ModelConfiguration;
using DiaryInWpf.Models.Domains;

namespace DiaryInWpf.Models.Configurations
{
    class RatingConfiguration : EntityTypeConfiguration<Rating>
    {
        public RatingConfiguration()
        {
            ToTable("dbo.Ratings");

            HasKey(x => x.Id);
        }
    }
}
