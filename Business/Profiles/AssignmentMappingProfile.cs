using AutoMapper;
using Business.Dtos.Assignment.Requests;
using Business.Dtos.Assignment.Responses;
using Business.Dtos.OperationClaim.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class AssignmentMappingProfile : Profile
    {
        public AssignmentMappingProfile()
        {
            CreateMap<Assignment, CreateAssignmentRequest>().ReverseMap();
            CreateMap<Assignment, CreatedAssignmentResponse>().ReverseMap();

            CreateMap<Assignment, UpdateAssignmentRequest>().ReverseMap();
            CreateMap<Assignment, UpdatedAssignmentResponse>().ReverseMap();

            CreateMap<Assignment, DeletedAssignmentResponse>().ReverseMap();
            CreateMap<Assignment, GetListAssignmentResponse>().ReverseMap();
            CreateMap<Assignment, GetAssignmentResponse>().ReverseMap();

            CreateMap<Paginate<Assignment>, Paginate<GetListAssignmentResponse>>().ReverseMap();

        }
    }
}
