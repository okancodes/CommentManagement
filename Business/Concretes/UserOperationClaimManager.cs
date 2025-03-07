﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.UserOperationClaim.Requests;
using Business.Dtos.UserOperationClaim.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;
        IMapper _mapper;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IMapper mapper)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _mapper = mapper;
        }
        public async Task<CreatedUserOperationClaimResponse> AddAsync(CreateUserOperationClaimRequest createUserOperationClaimRequest)
        {
            UserOperationClaim userOperationClaim = _mapper.Map<UserOperationClaim>(createUserOperationClaimRequest);
            var createdUserOperationClaim = await _userOperationClaimDal.AddAsync(userOperationClaim);
            CreatedUserOperationClaimResponse createdUserOperationClaimResponse = _mapper.Map<CreatedUserOperationClaimResponse>(createdUserOperationClaim);
            return createdUserOperationClaimResponse;
        }

        public async Task<DeletedUserOperationClaimResponse> DeleteAsync(DeleteUserOperationClaimRequest deleteUserOperationClaimRequest)
        {
            UserOperationClaim userOperationClaim = await _userOperationClaimDal.GetAsync(uoc => uoc.UserId == deleteUserOperationClaimRequest.UserId && uoc.OperationClaimId==deleteUserOperationClaimRequest.OperationClaimId);
            var deletedUserOperationClaim = await _userOperationClaimDal.DeleteAsync(userOperationClaim);
            DeletedUserOperationClaimResponse deletedUserOperationClaimResponse = _mapper.Map<DeletedUserOperationClaimResponse>(deletedUserOperationClaim);
            return deletedUserOperationClaimResponse;         
        }

        public async Task<Paginate<GetListUserOperationClaimResponse>> GetListAsync()
        {
            var userOperationClaim = await  _userOperationClaimDal.GetListAsync(include: u => u.Include(u => u.User).Include(c => c.OperationClaim));
            return _mapper.Map<Paginate<GetListUserOperationClaimResponse>>(userOperationClaim);
        }

        public async Task<Paginate<GetListUserOperationClaimResponse>> GetListByUserIdAsync(Guid userId)
        {
            var result = await _userOperationClaimDal.GetListAsync(uoc => uoc.UserId == userId);
            return _mapper.Map<Paginate<GetListUserOperationClaimResponse>>(result);
        }
    }
}
