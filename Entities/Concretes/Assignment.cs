using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Assignment : Entity<Guid>
    {
        public string Title { get; set; } 
        public string Description { get; set; } 
        public DateTime CreationDate { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserAssignment> UserAssignments { get; set; }


    }
}
