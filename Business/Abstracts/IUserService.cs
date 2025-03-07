﻿using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using Core.Entities.Abstract;
using Entities.Concretes;

namespace Business.Abstracts
{
    public interface IUserService
    {
        Task<Paginate<GetListUserResponse>> GetListAsync();
        Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest);
        Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest);
        Task<DeletedUserResponse> DeleteAsync(Guid userId);
        Task<GetByIdUserResponse> GetByIdAsync(Guid userId);
        Task<User> GetByMailAsync(string mail,bool withDeleted);
        Task<GetUserResponse> GetUserByMailAsync(string mail);
        List<IOperationClaim> GetClaims(IUser user);
    }
}
