using AutoMapper;
using Business.Dtos.OperationClaim.Requests;
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
    public class OperationClaimMappingProfile : Profile
    {
        public OperationClaimMappingProfile()
        {
            CreateMap<OperationClaim, CreateOperationClaimRequest>().ReverseMap();
            CreateMap<OperationClaim, CreatedOperationClaimResponse>().ReverseMap();

            CreateMap<OperationClaim, UpdateOperationClaimRequest>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimResponse>().ReverseMap();

            CreateMap<OperationClaim, DeletedOperationClaimResponse>().ReverseMap();
            CreateMap<OperationClaim, GetListOperationClaimResponse>().ReverseMap();
            CreateMap<OperationClaim, GetOperationClaimResponse>().ReverseMap();

            CreateMap<Paginate<OperationClaim>, Paginate<GetListOperationClaimResponse>>().ReverseMap();
        }
    }
}
