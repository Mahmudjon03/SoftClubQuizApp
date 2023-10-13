using Domain;
using Infrastructure.Servises.QuestionServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;


    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }
    [HttpGet("Get-questions")]
    public async Task<Response<List<GetQuestionDTO>>> GetQuestions()
    {
        return await _questionService.GetQuestions();
    }
    [HttpGet("Get-question")]
    public async Task<Response<GetQuestionDTO>> GetQuestion(int id)
    {
        return await _questionService.GetQuestion(id);
    }
    [HttpPost("Add-question")]
    public async Task<Response<string>> AddQuestion(AddQuestionDTO addQuestionDTO)
    {
        return await _questionService.AddQuestion(addQuestionDTO);
    }
    [HttpPut("Update-question")]
    public async Task<Response<string>> UpdateQuestion(UpdateQuestionDTO updateQuestionDTO)
    {
        return await _questionService.UpdateQuestion(updateQuestionDTO);
    }
    [HttpDelete("Delete-question")]
    public async Task<Response<string>> DleteQuestion(int id)
    {
        return await _questionService.DleteQuestion(id);
    }
}
