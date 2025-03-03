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

            //builder.HasData(new Article
            //{
            //    Id = 1,
            //    CategoryId = 1,
            //    Title = "C# 9.0 ve .NET 5 Yenilikleri",
            //    Content = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Bu yazılar öylesine oluşturulmuş yazılardır ve yer kaplamak amacıyla kullanılmaktadır.",
            //    Thumbnail = "Default.jpg",
            //    SeoAuthor = "John Doe",
            //    SeoDescription = "C# 9.0 ve .NET 5 Yenilikleri hakkında yazılan yazılar.",
            //    SeoTags = "C#, C# 9.0, .Net Framework, .Net 5, Entity Framework",
            //    Date = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedByName = "InitialCreate",
            //    CreatedDate = DateTime.Now,
            //    ModifiedByName = "InitialCreate",
            //    ModifiedDate = DateTime.Now,
            //    Note = "İlk makale.",
            //    UserId = 1,
            //    ViewsCount = 100,
            //    CommentCount = 1

            //}, new Article
            //{
            //    Id = 2,
            //    CategoryId = 2,
            //    Title = "C++ 11 ve 15 Yenilikleri",
            //    Content = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Bu yazılar öylesine oluşturulmuş yazılardır ve yer kaplamak amacıyla kullanılmaktadır. Gerçeklerle uzaktan yakından ilişkisi yoktur",
            //    Thumbnail = "Default.jpg",
            //    SeoAuthor = "John Doe",
            //    SeoDescription = "C++ 11 ve 15 Yenilikleri hakkında yazılan yazılar.",
            //    SeoTags = "C++, C++ 11, C++ 15",
            //    Date = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedByName = "InitialCreate",
            //    CreatedDate = DateTime.Now,
            //    ModifiedByName = "InitialCreate",
            //    ModifiedDate = DateTime.Now,
            //    Note = "İkinci makale.",
            //    UserId = 1,
            //    ViewsCount = 38,
            //    CommentCount = 0
            //}, new Article
            //{
            //    Id = 3,
            //    CategoryId = 3,
            //    Title = "Javascript Nedir?",
            //    Content = "Lorem ipsum dolor sit amet consectetur adipiscing elit. Burada javascript dili ile ilgili bilgiler yer almaktadır.",
            //    Thumbnail = "Default.jpg",
            //    SeoAuthor = "John Doe",
            //    SeoDescription = "Javascript Nedir? hakkında yazılan yazılar.",
            //    SeoTags = "Javascript, Js, Ecmascript, Vanillascript",
            //    Date = DateTime.Now,
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedByName = "InitialCreate",
            //    CreatedDate = DateTime.Now,
            //    ModifiedByName = "InitialCreate",
            //    ModifiedDate = DateTime.Now,
            //    Note = "Üçüncü makale.",
            //    UserId = 1,
            //    ViewsCount = 22,
            //    CommentCount = 1

            //});
        }
    }
}
