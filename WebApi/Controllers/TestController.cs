using Domain;
using Infrastructure.Servises.TestServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ITestService _testService;


    public TestController(ITestService testService)
    {
        _testService = testService;
    }
    // git add .
    // git commit -m "version 2"
    // git push origin main 
    
    [HttpGet("Get-tests")]
    public async Task<Response<List<GetTestDTO>>> GetTests()
    {
        return await _testService.GetTests();
    }
    [HttpGet("Get-test")]
    public async Task<Response<GetTestDTO>> GetTest(int id)
    {
        return await _testService.GetTest(id);
    }
    [HttpPost("Add-test")]
    public async Task<Response<string>> AddTest(AddTestDTO addTestDTO)
    {
        return await _testService.AddTest(addTestDTO);
    }
    [HttpPut("Update-test")]
    public async Task<Response<string>> UpdateTest(UpdateTestDTO updateTestDTO)
    {
        return await _testService.UpdateTest(updateTestDTO);
    }
    [HttpDelete("Delete-test")]
    public async Task<Response<string>> DeleteTest(int id)
    {
        return await _testService.DeleteTest(id);
    }
}
