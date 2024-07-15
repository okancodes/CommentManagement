using Business.Dtos.Assignment.Requests;
using Business.Dtos.Assignment.Responses;
using Business.Dtos.Comment.Requests;
using Business.Dtos.Comment.Responses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICommentService
    {
        Task<CreatedCommentResponse> AddAsync(CreateCommentRequest createCommentRequest);
        Task<UpdatedCommentResponse> UpdateAsync(UpdateCommentRequest updateCommentRequest);
        Task<DeletedCommentResponse> DeleteAsync(Guid commentId);
        Task<Paginate<GetListCommentResponse>> GetListAsync();
        Task<GetCommentResponse> GetByIdAsync(Guid commentId);
    }
}
