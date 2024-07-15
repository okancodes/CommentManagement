using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Assignment.Requests;
using Business.Dtos.Assignment.Responses;
using Business.Dtos.Comment.Requests;
using Business.Dtos.Comment.Responses;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
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
    public class CommentManager : ICommentService
    {
        private ICommentDal _commentDal;
        private IMapper _mapper;

        public CommentManager(ICommentDal commentDal, IMapper mapper)
        {
            _commentDal = commentDal;
            _mapper = mapper;
        }
        public async Task<CreatedCommentResponse> AddAsync(CreateCommentRequest createCommentRequest)
        {
            var comment = _mapper.Map<Comment>(createCommentRequest);
            var createdCommentResponse = await _commentDal.AddAsync(comment);
            return _mapper.Map<CreatedCommentResponse>(comment);

        }

        public async Task<DeletedCommentResponse> DeleteAsync(Guid commentId)
        {
            Comment comment = await _commentDal.GetAsync(u => u.Id == commentId);
            var deletedComment = await _commentDal.DeleteAsync(comment);
            DeletedCommentResponse deletedCommentResponse = _mapper.Map<DeletedCommentResponse>(deletedComment);
            return deletedCommentResponse;
        }

        public async Task<GetCommentResponse> GetByIdAsync(Guid commentId)
        {
            Comment comment = await _commentDal.GetAsync(u => u.Id == commentId);
            return _mapper.Map<GetCommentResponse>(comment);
        }

        public async Task<Paginate<GetListCommentResponse>> GetListAsync()
        {
            var commenttList = await _commentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListCommentResponse>>(commenttList);
        }

        public async Task<UpdatedCommentResponse> UpdateAsync(UpdateCommentRequest updateCommentRequest)
        {
            Comment comment = await _commentDal.GetAsync(p => p.Id == updateCommentRequest.Id);
            _mapper.Map(updateCommentRequest, comment);
            comment = await _commentDal.UpdateAsync(comment);
            return _mapper.Map<UpdatedCommentResponse>(comment);
        }
    }
}
