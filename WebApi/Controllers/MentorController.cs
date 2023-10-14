using Domain;
using Domain.GetFilter;
using Infrastructure.Servises.MentorServise;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("controller")]
    public class MentorController : ControllerBase
    {
        private readonly IMentorServise _mentor;

        public MentorController(IMentorServise mentor)
        {
            _mentor = mentor;
        }
        [HttpGet("GetMentor")]
    public async Task<PoginationResponse<List<GetUserDto>>> GetMentor([FromQuery]GetFilter filter) =>await _mentor.GetMentor(filter);
        [HttpPost("AddMentor")]
     public  async Task<Response<GetUserDto>> AddMentor(int id)=> await _mentor.AddMentor(id);
    }

}
