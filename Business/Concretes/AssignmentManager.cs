using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Assignment.Requests;
using Business.Dtos.Assignment.Responses;
using Business.Dtos.OperationClaim.Requests;
using Business.Dtos.OperationClaim.Responses;
using Business.Dtos.User.Requests;
using Business.Dtos.User.Responses;
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
    public class AssignmentManager : IAssignmentService
    {
        private IAssignmentDal _assignmentDal;
        private IMapper _mapper;

        public AssignmentManager(IAssignmentDal assignmentDal, IMapper mapper)
        {
            _assignmentDal = assignmentDal;
            _mapper = mapper;
        }
        public async Task<CreatedAssignmentResponse> AddAsync(CreateAssignmentRequest createAssignmentRequest)
        {
            Assignment assignment = _mapper.Map<Assignment>(createAssignmentRequest);
            assignment.Id = Guid.NewGuid();
            Assignment createdAssignment = await _assignmentDal.AddAsync(assignment);
            return _mapper.Map<CreatedAssignmentResponse>(createdAssignment);
        }

        public async Task<DeletedAssignmentResponse> DeleteAsync(Guid assignmentId)
        {
            Assignment assignment = await _assignmentDal.GetAsync(u => u.Id == assignmentId);
            var deletedAssignmet = await _assignmentDal.DeleteAsync(assignment);
            DeletedAssignmentResponse deletedAssignmentResponse = _mapper.Map<DeletedAssignmentResponse>(deletedAssignmet);
            return deletedAssignmentResponse;
        }

        public async Task<GetAssignmentResponse> GetByIdAsync(Guid assignmentId)
        {
            Assignment assignment = await _assignmentDal.GetAsync(u => u.Id == assignmentId);
            return _mapper.Map<GetAssignmentResponse>(assignment);
        }

        public async Task<Paginate<GetListAssignmentResponse>> GetListAsync()
        {
            var assignmentList = await _assignmentDal.GetListAsync();
            return _mapper.Map<Paginate<GetListAssignmentResponse>>(assignmentList);
        }

        public async Task<UpdatedAssignmentResponse> UpdateAsync(UpdateAssignmentRequest updateAssignmentRequest)
        {
            Assignment assignment = await _assignmentDal.GetAsync(p => p.Id == updateAssignmentRequest.Id);
            _mapper.Map(updateAssignmentRequest, assignment);
            assignment = await _assignmentDal.UpdateAsync(assignment);
            return _mapper.Map<UpdatedAssignmentResponse>(assignment);

        }
    }
}
