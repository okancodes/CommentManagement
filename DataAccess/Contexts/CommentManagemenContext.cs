//using Castle.Core.Configuration;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Contexts
{
    public class CommentManagemenContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments{ get; set; }
        public DbSet<Assignment> Assignments{ get; set; }   
        public DbSet<OperationClaim> OperationClaims{ get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims{ get; set; }
        public DbSet<UserAssignment> UserAssignments { get; set; }
        public CommentManagemenContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
