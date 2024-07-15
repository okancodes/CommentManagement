using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class UserAssignmentConfiguration : IEntityTypeConfiguration<UserAssignment>
    {
        public void Configure(EntityTypeBuilder<UserAssignment> builder)
        {
            builder.ToTable("UserAssignment").Ignore(uo => uo.Id);
            builder.HasKey(uop => new { uop.UserId, uop.AssignmentId });

            builder.Property(uo => uo.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(uo => uo.AssignmentId).HasColumnName("AssignmentId").IsRequired();

            builder.HasOne(uo => uo.User).WithMany(u => u.UserAssignments).HasForeignKey(uo => uo.UserId);
            builder.HasOne(uo => uo.Assignment).WithMany(u => u.UserAssignments).HasForeignKey(uo => uo.AssignmentId);

            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
        }
    }
}
