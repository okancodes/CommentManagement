using AutoMapper;
using Business.Dtos.UserOperationClaim.Requests;
using Business.Dtos.UserOperationClaim.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserOperationClaimMappingProfile:Profile
    {
        public UserOperationClaimMappingProfile()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimRequest>().ReverseMap();
            CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>().ReverseMap();

            CreateMap<UserOperationClaim, DeleteUserOperationClaimRequest>().ReverseMap();
            CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>().ReverseMap();

            CreateMap<UserOperationClaim, GetUserOperationClaimRequest>().ReverseMap();
            CreateMap<UserOperationClaim, GetUserOperationClaimResponse>().ReverseMap();

            CreateMap<UserOperationClaim, GetListUserOperationClaimResponse>().ReverseMap();

            CreateMap<Paginate<UserOperationClaim>, Paginate<GetListUserOperationClaimResponse>>().ReverseMap();
        }

    }
}
