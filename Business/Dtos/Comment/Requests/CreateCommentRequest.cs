using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Comment.Requests
{
    public class CreateCommentRequest
    {
        public Guid AssignmentId { get; set; }

        public string Content { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
