using Core.DataAccess.Repositories;
using Core.Entities.Abstract;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfUserDal : EfRepositoryBase<User, Guid, CommentManagemenContext>, IUserDal
    {
        public CommentManagemenContext _commentManagemenContext;
        public IOperationClaim _getClaims;

        public EfUserDal(CommentManagemenContext commentManagemenContext):base(commentManagemenContext)
        {
            _commentManagemenContext = commentManagemenContext;
        }

        public List<IOperationClaim> GetClaims(IUser user)
        {
            var result = from operationClaim in _commentManagemenContext.OperationClaims
                         join userOperationClaim in _commentManagemenContext.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select (IOperationClaim)(new OperationClaim { Name = operationClaim.Name });
            return result.ToList();
        }
    }
}
