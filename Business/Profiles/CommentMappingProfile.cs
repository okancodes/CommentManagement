using AutoMapper;
using Business.Dtos.Assignment.Responses;
using Business.Dtos.Comment.Requests;
using Business.Dtos.Comment.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CommentMappingProfile : Profile
    {
        public CommentMappingProfile()
        {
            CreateMap<Comment, CreateCommentRequest>().ReverseMap();
            CreateMap<Comment, CreatedCommentResponse>().ReverseMap();

            CreateMap<Comment, UpdateCommentRequest>().ReverseMap();
            CreateMap<Comment, UpdatedCommentResponse>().ReverseMap();

            CreateMap<Comment, DeletedCommentResponse>().ReverseMap();
            CreateMap<Comment, GetListCommentResponse>().ReverseMap();
            CreateMap<Comment, GetCommentResponse>().ReverseMap();

            CreateMap<Paginate<Comment>, Paginate<GetListCommentResponse>>().ReverseMap();

        }
    }
}
