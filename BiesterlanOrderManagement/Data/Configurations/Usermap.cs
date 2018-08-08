using BiesterlanOrders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Orders).WithOne(u=>u.User).HasForeignKey(o=>o.UserId);
            builder.HasIndex(u => u.Name).IsUnique();
            
        }
    }
}
