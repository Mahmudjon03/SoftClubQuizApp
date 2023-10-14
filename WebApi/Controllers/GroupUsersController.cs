using Domain.DTOs.GroupDto;
using Domain;
using Infrastructure.Servises.AddStudentNewGroup;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class GroupUsersController
    {
        private readonly IGroupStudentServise _student;

        public GroupUsersController(IGroupStudentServise student)
        {
            _student = student;
        }



        [HttpPost("AddStudentToGroup")]
        public async Task<Response<GetGroupDto>> AddStudentToGroup(AddStudentToGroupDto userGroup) => await _student.AddStudentToGroup(userGroup);

        [HttpPost("AddMentorToGrpoup")]
        public async Task<Response<GetGroupDto>> addMentor(AddStudentToGroupDto userGroup) => await _student.AddMentorToGroup(userGroup);

        [HttpDelete("DeleteStudent")]
        public async Task<Response<GetGroupDto>> DeleteStudent(AddStudentToGroupDto model) => await _student.DeleteStudent(model);

        [HttpDelete("DeleteMentor")]
        public async Task<Response<GetGroupDto>> DeleteMentor(AddStudentToGroupDto model) => await _student.DeleteStudent(model);
       
        [HttpPost("TransferStudentToGroup")]
        public async Task<Response<GetGroupDto>> TaransferStudent(TransferStudentNewGroup model) => await _student.TransferStudentToNewGroup(model);



    }
}
