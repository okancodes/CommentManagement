using AutoMapper;
using Business.Abstracts;
using Business.Dtos.OperationClaim.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using Core.Entities.Abstract;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
            
        }

        public async Task<CreatedUserResponse> AddAsync(CreateUserRequest createUserRequest)
        {
            User user = _mapper.Map<User>(createUserRequest);
            user.Id = Guid.NewGuid();
            User createdUser = await _userDal.AddAsync(user);
            return _mapper.Map<CreatedUserResponse>(createdUser);
        }

        public async Task<DeletedUserResponse> DeleteAsync(Guid userId)
        {
            User user = await _userDal.GetAsync(u=> u.Id == userId);
            var deletedUser = await _userDal.DeleteAsync(user);
            DeletedUserResponse deletedUserResponse = _mapper.Map<DeletedUserResponse>(deletedUser);
            return deletedUserResponse;
        }

        public async Task<GetByIdUserResponse> GetByIdAsync(Guid userId)
        {
            User user = await _userDal.GetAsync(u=>u.Id == userId);
            return _mapper.Map<GetByIdUserResponse>(user);

        }
        public async Task<UpdatedUserResponse> UpdateAsync(UpdateUserRequest updateUserRequest)
        {
            User user = _mapper.Map<User>(updateUserRequest);
            var updatedUser = await _userDal.UpdateAsync(user);
            UpdatedUserResponse updatedUserResponse = _mapper.Map<UpdatedUserResponse>(updatedUser);
            return updatedUserResponse;
        }

        public async Task<Paginate<GetListUserResponse>> GetListAsync()
        {
            var data = await _userDal.GetListAsync();
            return _mapper.Map<Paginate<GetListUserResponse>>(data);
        }
        public async Task<GetUserResponse> GetUserByMailAsync(string mail)
        {
            var userResult = await _userDal.GetAsync(u => u.Email == mail);
            return _mapper.Map<GetUserResponse>(userResult);
        }
        public async Task<User> GetByMailAsync(string mail, bool withDeleted)
        {
            var result = await _userDal.GetAsync(u => u.Email == mail, withDeleted: withDeleted);
            return result;
        }


        public List<IOperationClaim> GetClaims(IUser user)
        {
            var result = _userDal.GetClaims(user);
            return result;

        }
    }
}
