using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogProject.Data.Migrations
{
    public partial class SeedingArticles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO BlogProjectDb.dbo.Articles (Title, Content, Thumbnail, [Date], ViewsCount, CommentCount, SeoAuthor, SeoDescription, SeoTags, CategoryId, UserId, CreatedDate, ModifiedDate, IsDeleted, IsActive, CreatedByName, ModifiedByName, Note) VALUES(N'C++ ile Algoritma Yapıları', N'lorem ipsum dolor sit amet consectetur adipiscing elit.', N'postImages/defaultImage.jpg', '2025-02-27 23:20:09.151', 0, 0, N'Migration', N'Migration', N'c++,cpp', 1, 1, '2025-02-27 23:20:09.151', '2025-02-27 23:20:09.151', 0, 1, N'ADMIN', N'ADMIN', NULL);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
