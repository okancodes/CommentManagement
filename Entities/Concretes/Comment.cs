using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Comment : Entity<Guid>
    {

        public Guid AssignmentId { get; set; }

        public string Content { get; set; }

        public DateTime CommentDate { get; set; }

        public Assignment Assignment { get; set; }

    }
}
