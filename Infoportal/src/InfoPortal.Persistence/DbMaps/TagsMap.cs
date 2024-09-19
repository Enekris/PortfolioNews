using InfoPortal.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoPortal.Persistence.DbMaps
{
    public class TagsMap : IEntityTypeConfiguration<TagDb>
    {
        public void Configure(EntityTypeBuilder<TagDb> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).HasColumnName("Name");
            builder.HasIndex(e => e.Name).IsUnique();
            builder.Property(e => e.CreateDate).HasColumnName("CreateDate");
            builder.Property(e => e.UpdateDate).HasColumnName("UpdateDate");

        }
    }
}
