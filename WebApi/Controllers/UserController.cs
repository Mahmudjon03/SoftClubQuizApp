using Domain;
using Domain.GetFilter;
using Infrastructure.Servises.UserServise;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController:ControllerBase
    {
        private readonly IUserServise _user;

        public UserController(IUserServise user)
        {
            _user = user;
        }
        [HttpGet("GetUser")]
      public  async Task<PoginationResponse<List<GetUserDto>>> Get([FromQuery]GetFilter filter) => await _user.GetUser(filter);
        [HttpPost("Adduser")]
      public  async Task<Response<GetUserDto>>  Add([FromForm]AddUserDto user)=> await _user.AddUser(user);

        [HttpDelete("DeleteUsers")]
        public async Task<Response<GetUserDto>> Delete(int id)=> await _user.DeleteUser(id);

        [HttpGet("GetById")]
        public async Task<Response<GetUserDto>> GetById(int id)=> await _user.GetUserById(id);
        [HttpPut("UpdateUser")]
        public async Task<Response<GetUserDto>> Update(AddUserDto user)=> await _user.UpdateUser(user);

    }
}
