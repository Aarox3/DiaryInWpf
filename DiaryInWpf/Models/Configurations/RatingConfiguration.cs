using DiaryInWpf.Models.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaryInWpf.Models.Configurations
{
    class RatingConfiguration : EntityTypeConfiguration<Rating>
    {
        {
            public void Configure(EntityTypeBuilder<Rating> builder)
            {
                builder.ToTable("dbo.Ratings");

                builder.HasKey(x => x.Id);
            }
        }
    }
