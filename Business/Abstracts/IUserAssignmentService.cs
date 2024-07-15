using Business.Dtos.UserAssignment.Requests;
using Business.Dtos.UserAssignment.Responses;
using Business.Dtos.UserOperationClaim.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IUserAssignmentService
    {
        Task<CreatedUserAssignmentResponse> AddAsync(CreateUserAssignmentRequest createUserAssignmentRequest);
        Task<Paginate<GetListUserAssignmentResponse>> GetListByUserIdAsync(Guid userId);
        Task<Paginate<GetListUserAssignmentResponse>> GetListAsync();
        Task<DeletedUserAssignmentResponse> DeleteAsync(DeleteUserAssignmentRequest deleteUserAssignmentRequest ); 
    }
}
