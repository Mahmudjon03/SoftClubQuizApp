using Domain;
using Domain.DTOs.GroupDto;
using Domain.GetFilter;
using Infrastructure.Servises.GroupServises;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class GroupController:ControllerBase
    {
        private readonly IGroupServise _group;

        public GroupController(IGroupServise group) => _group = group;
      
        [HttpGet("GetGroup")]
        public async Task<PoginationResponse<List<GetGroupDto>>> Get([FromQuery] GetFilter filter) => await _group.GetGroup(filter);
     
        [HttpGet("GetGroupById")]
        public async Task<Response<GetGroupDto>> GetById(int id) => await _group.GetById(id);
       
        [HttpDelete("DeleteGroup")]
        public async Task<Response<GetGroupDto>> Delete(int id) => await _group.Delete(id);
       
        [HttpPut("UpdateGroup")]
        public async Task<Response<GetGroupDto>> Update(AddGroupDto model) => await _group.Update(model);
       
        [HttpPost("AddGroups")]
        public async Task<Response<GetGroupDto>> AddGroup([FromForm] AddGroupDto model) => await _group.AddGroup(model);
       
        [HttpPost("AddStudentToGroup")]
        public async Task<Response<GetGroupDto>> AddStudentToGroup(AddStudentToGroupDto userGroup)=> await _group.AddStudentToGroup(userGroup);
      
        [HttpPost("AddMentorToGrpoup")]
        public async Task<Response<GetGroupDto>> addMentor(AddStudentToGroupDto userGroup) => await _group.AddMentorToGroup(userGroup);
       
        [HttpDelete("DeleteStudent")]
        public async Task<Response<GetGroupDto>> DeleteStudent(int id ,int ig)=>await _group.DeleteStudent(id,ig);
      
      //  [HttpPut("DeleteMentor")]
      // public async Task<Response<GetGroupDto>> DeleteMentor(int id) => await _group.DeleteStudent(id);

        [HttpGet("GetMentorFromGroup")]
        public async Task<PoginationResponse<List<GetGroupDto>>> GetMentor([FromQuery]GetFilter filter) => await _group.GetMentor(filter);

        [HttpGet("GetStudentFromGroup")]
        public async Task<PoginationResponse<List<GetGroupDto>>> GetStudent([FromQuery]GetFilter filter) => await _group.GetStudent(filter);




    }
}
