using AutoMapper;
using Business.Abstracts;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Business.Dtos.User.Responses;
using Business.Dtos.UserOperationClaim.Requests;
using Business.Dtos.UserOperationClaim.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class OperationClaimManager : IOperationClaimService
    {
        IMapper _mapper;
        IOperationClaimDal _operationClaimDal;
        IUserOperationClaimService _userOperationClaimService;

        public OperationClaimManager(IMapper mapper, IOperationClaimDal operationClaimDal, IUserOperationClaimService userOperationClaimService)
        {
            _mapper = mapper;
            _operationClaimDal = operationClaimDal;
            _userOperationClaimService = userOperationClaimService;
        }
        public async Task<CreatedOperationClaimResponse> AddAsync(CreateOperationClaimRequest createOperationClaimRequest)
        {
            OperationClaim operationClaim = _mapper.Map<OperationClaim>(createOperationClaimRequest);
            var createdOperationClaimResponse = await _operationClaimDal.AddAsync(operationClaim);
            CreatedOperationClaimResponse result = _mapper.Map<CreatedOperationClaimResponse>(operationClaim);
            return result;
        }

        public async Task<CreatedUserOperationClaimResponse> AssignOperationClaimToUserAsync(CreateUserOperationClaimRequest createUserOperationClaimRequest)
        {
            return await _userOperationClaimService.AddAsync(createUserOperationClaimRequest);
        }

        public async Task<DeletedOperationClaimResponse> DeleteAsync(Guid operationClaimId)
        {
            OperationClaim operationClaim = await _operationClaimDal.GetAsync(u => u.Id == operationClaimId);
            var deletedOperationClaim = await _operationClaimDal.DeleteAsync(operationClaim);
            DeletedOperationClaimResponse deletedOperationClaimResponse = _mapper.Map<DeletedOperationClaimResponse>(deletedOperationClaim);
            return deletedOperationClaimResponse;
        }

        public async Task<GetOperationClaimResponse> GetByIdAsync(Guid operationClaimId)
        {
            OperationClaim operationClaim = await _operationClaimDal.GetAsync(oc => oc.Id == operationClaimId);
            return _mapper.Map<GetOperationClaimResponse>(operationClaim);

        }

        public async Task<Paginate<GetListOperationClaimResponse>> GetListAsync()
        {
            var operationClaim = await _operationClaimDal.GetListAsync();
            return _mapper.Map<Paginate<GetListOperationClaimResponse>>(operationClaim);
        }

        public async Task<UpdatedOperationClaimResponse> UpdateAsync(UpdateOperationClaimRequest updateOperationClaimRequest)
        {
            OperationClaim operationClaim = await _operationClaimDal.GetAsync(p => p.Id == updateOperationClaimRequest.Id);
            _mapper.Map(updateOperationClaimRequest, operationClaim);
            operationClaim = await _operationClaimDal.UpdateAsync(operationClaim);
            return _mapper.Map<UpdatedOperationClaimResponse>(operationClaim);

        }
    }
}
