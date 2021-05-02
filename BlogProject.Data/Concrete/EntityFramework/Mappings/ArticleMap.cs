using BlogProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();
            builder.Property(x => x.Title)
                .IsRequired(true)
                .HasMaxLength(100);
            builder.Property(x => x.Content)
                .IsRequired()
                .HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.Date)
                .IsRequired();
            builder.Property(x => x.SeoAuthor)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.SeoDescription)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.SeoTags)
                .IsRequired()
                .HasMaxLength(70);
            builder.Property(x => x.ViewsCount).IsRequired();
            builder.Property(x => x.CommentCount).IsRequired();
            builder.Property(x => x.Thumbnail).IsRequired().HasMaxLength(250);
            builder.Property(x => x.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);

            builder.HasOne<Category>(x => x.Category)
                .WithMany(cat => cat.Articles)
                .HasForeignKey(x => x.CategoryId);
            builder.HasOne<User>(x => x.User)
                .WithMany(user => user.Articles)
                .HasForeignKey(x => x.UserId);
            builder.ToTable("Articles");
        }
    }
}
