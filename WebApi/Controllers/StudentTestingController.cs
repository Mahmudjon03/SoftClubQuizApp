using Domain;
using Infrastructure.Servises.StudentTestingServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentTestingController : ControllerBase
{
    private readonly IStudentTestingService _studentTestingService;


    public StudentTestingController(IStudentTestingService studentTestingService)
    {
        _studentTestingService = studentTestingService;
    }
    [HttpPost("AddStudentTest")]
    public async Task<Response<AddStudentTestDto>> AddStudentTest([FromForm]AddStudentTestDto model)
    {
        return await _studentTestingService.AddStudentTest(model);
    }
}
