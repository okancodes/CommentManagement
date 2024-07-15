using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.UserAssignment.Responses
{
    public class DeletedUserAssignmentResponse
    {
        public Guid UserId { get; set; }
        public Guid AssignmentId { get; set; }
    }
}
