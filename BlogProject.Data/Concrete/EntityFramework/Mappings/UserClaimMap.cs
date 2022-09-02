using BlogProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Data.Concrete.EntityFramework.Mappings
{
    public class UserClaimMap : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("AspNetUserClaims");
        }
    }
}
