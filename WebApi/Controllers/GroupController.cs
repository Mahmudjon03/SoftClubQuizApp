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
       
       
        [HttpGet("GetMentorFromGroup")]
        public async Task<PoginationResponse<List<GetGroupDto>>> GetMentor([FromQuery]GetFilter filter) => await _group.GetMentor(filter);

        [HttpGet("GetStudentFromGroup")]
        public async Task<PoginationResponse<List<GetGroupDto>>> GetStudent([FromQuery]GetFilter filter) => await _group.GetStudent(filter);




    }
}
