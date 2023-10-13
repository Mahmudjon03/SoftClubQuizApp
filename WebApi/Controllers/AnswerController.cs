
using Domain;
using Infrastructure.Servises.AnswerServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswerController : ControllerBase
{
    private readonly IAnswerService _answerService;


    public AnswerController(IAnswerService answerService)
    {
        _answerService = answerService;
    }
    [HttpPost("Add-answer")]
    public async Task<Response<string>> AddAnswer(AddAnswerDTO addAnswerDTO)
    {
        return await _answerService.AddAnswer(addAnswerDTO);
    }
    [HttpPut("Update-answer")]
    public async Task<Response<string>> UpdateAnswer(UpdateUnswerDTO updateUnswerDTO)
    {
        return await _answerService.UpdateAnswer(updateUnswerDTO);
    }
    [HttpDelete("Delete-answer")]
    public async Task<Response<string>> DleteAnswer(int id)
    {
        return await _answerService.DleteAnswer(id);
    }
}
