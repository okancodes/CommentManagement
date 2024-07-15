using AutoMapper;
using Business.Abstracts;
using Business.Dtos.UserAssignment.Requests;
using Business.Dtos.UserAssignment.Responses;
using Business.Dtos.UserOperationClaim.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserAssignmentManager : IUserAssignmentService
    {
        IUserAssignmentDal _userAssignmentDal;
        IMapper _mapper;

        public UserAssignmentManager(IUserAssignmentDal userAssignmentDal, IMapper mapper)
        {
            _userAssignmentDal = userAssignmentDal;
            _mapper = mapper;
        }
        public async Task<CreatedUserAssignmentResponse> AddAsync(CreateUserAssignmentRequest createUserAssignmentRequest)
        {
            UserAssignment userAssignment = _mapper.Map<UserAssignment>(createUserAssignmentRequest);
            var createdUserAssignment = await _userAssignmentDal.AddAsync(userAssignment);
            CreatedUserAssignmentResponse createdUserAssignmentResponse = _mapper.Map<CreatedUserAssignmentResponse>(createdUserAssignment);
            return createdUserAssignmentResponse;
        }

        public async Task<DeletedUserAssignmentResponse> DeleteAsync(DeleteUserAssignmentRequest deleteUserAssignmentRequest)
        {
            UserAssignment userAssignment = await _userAssignmentDal.GetAsync(uoc => uoc.UserId == deleteUserAssignmentRequest.UserId && uoc.AssignmentId == deleteUserAssignmentRequest.AssignmentId);
            var deletedUserAssignment = await _userAssignmentDal.DeleteAsync(userAssignment);
            DeletedUserAssignmentResponse deletedUserAssignmentResponse = _mapper.Map<DeletedUserAssignmentResponse>(deletedUserAssignment);
            return deletedUserAssignmentResponse;
        }

        public async Task<Paginate<GetListUserAssignmentResponse>> GetListByUserIdAsync(Guid userId)
        {
            var result = await _userAssignmentDal.GetListAsync(uoc => uoc.UserId == userId);
            return _mapper.Map<Paginate<GetListUserAssignmentResponse>>(result);
        }

        public async Task<Paginate<GetListUserAssignmentResponse>> GetListAsync()
        {
            var userOperationClaim = await _userAssignmentDal.GetListAsync(include: u => u.Include(u => u.User).Include(c => c.Assignment));
            return _mapper.Map<Paginate<GetListUserAssignmentResponse>>(userOperationClaim);
        }
    }
}
