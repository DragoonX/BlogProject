﻿using BlogProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Data.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.HasIndex(x => x.Email).IsUnique(); //her kullanıcının benzersiz email adresi olması kuralı
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.Username).HasMaxLength(20);
            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.Property(x => x.PasswordHash).HasColumnType("VARBINARY(500)");
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(30);
            builder.Property(x => x.Picture).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(250);
            builder.Property(x => x.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.ToTable("Users");

            builder.HasOne<Role>(x => x.Role).WithMany(role => role.Users).HasForeignKey(x => x.RoleId);

        }
    }
}