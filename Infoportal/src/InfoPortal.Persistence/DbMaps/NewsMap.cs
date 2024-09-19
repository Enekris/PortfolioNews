using InfoPortal.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoPortal.Persistence.DbMaps
{
    public class NewsMap : IEntityTypeConfiguration<NewsDb>
    {
        public void Configure(EntityTypeBuilder<NewsDb> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Header).HasColumnName("Header");
            builder.Property(e => e.Text).HasColumnName("Text");
            builder.Property(e => e.CreateDate).HasColumnName("CreateDate");
            builder.Property(e => e.UpdateDate).HasColumnName("UpdateDate");
            builder.HasMany(n => n.Tags).WithMany(t => t.News);
        }
    }
}
