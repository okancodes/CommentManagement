using AutoMapper;
using Business.Dtos.UserAssignment.Requests;
using Business.Dtos.UserAssignment.Responses;
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
    public class UserAssignmentMappingProfile : Profile
    {
        public UserAssignmentMappingProfile()
        {
            CreateMap<UserAssignment, CreateUserAssignmentRequest>().ReverseMap();
            CreateMap<UserAssignment, CreatedUserAssignmentResponse>().ReverseMap();

            CreateMap<UserAssignment, DeleteUserAssignmentRequest>().ReverseMap();
            CreateMap<UserAssignment, DeletedUserAssignmentResponse>().ReverseMap();

            CreateMap<UserAssignment, GetUserAssignmentRequest>().ReverseMap();
            CreateMap<UserAssignment, GetUserAssignmentResponse>().ReverseMap();

            CreateMap<UserAssignment, GetListUserAssignmentResponse>().ReverseMap();

            CreateMap<Paginate<UserAssignment>, Paginate<GetListUserAssignmentResponse>>().ReverseMap();
        }
    }
}
