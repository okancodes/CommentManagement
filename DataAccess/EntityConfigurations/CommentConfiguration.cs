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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments").HasKey(op => op.Id);

            builder.Property(op => op.Id).HasColumnName("Id").IsRequired();
            builder.Property(op => op.AssignmentId).HasColumnName("AssignmentId").IsRequired();
            builder.Property(op => op.Content).HasColumnName("Content").IsRequired();
            builder.Property(op => op.CommentDate).HasColumnName("CommentDate").IsRequired();

            builder.HasQueryFilter(op => !op.DeletedDate.HasValue);
        }

      
    }
}
