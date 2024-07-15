using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").Ignore(uo => uo.Id);
            builder.HasKey(uop => new { uop.UserId, uop.OperationClaimId });

            builder.Property(uo => uo.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(uo => uo.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

            builder.HasOne(uo => uo.User).WithMany(u => u.UserOperationClaims).HasForeignKey(uo => uo.UserId);
            builder.HasOne(uo => uo.OperationClaim).WithMany(u => u.UserOperationClaims).HasForeignKey(uo => uo.OperationClaimId);


            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
        }
    }
}