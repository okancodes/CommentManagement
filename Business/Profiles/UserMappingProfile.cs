using AutoMapper;
using Business.Dtos.Auth.Requests;
using Business.Dtos.Auth.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<User, CreatedUserResponse>().ReverseMap();

            CreateMap<User, UpdateUserRequest>().ReverseMap();
            CreateMap<User, UpdatedUserResponse>().ReverseMap();

            CreateMap<User, DeletedUserResponse>().ReverseMap();
            CreateMap<User, GetByIdUserResponse>().ReverseMap();
            CreateMap<User, GetListUserResponse>().ReverseMap();
            CreateMap<User, GetUserResponse>().ReverseMap();

            CreateMap<GetUserResponse, LoginResponse>().ReverseMap();
            CreateMap<CreatedUserResponse, RegisterResponse>().ReverseMap();

            CreateMap<User, RegisterRequest>().ReverseMap().ForMember(u => u.PasswordHash, opt => opt.MapFrom(r => r._passwordHash))
                .ForMember(u => u.PasswordSalt, opt => opt.MapFrom(r => r._passwordSalt));

            CreateMap<Paginate<User>, Paginate<GetListUserResponse>>().ReverseMap();


        }
    }
}
