using AutoMapper;
using Domain;
using Domain.Enums;
using Domain.Wapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Servises.StudentTestingServices;

public class StudentTestingService : IStudentTestingService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public StudentTestingService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<Response<AddStudentTestDto>> AddStudentTest(AddStudentTestDto model)
    {
        var student = await _dataContext.Users.FirstOrDefaultAsync(x=>x.UserType==UserType.Student && x.Id==model.StudentId);
        if(student==null) return new Response<AddStudentTestDto>(System.Net.HttpStatusCode.NotFound,"Student not found !");

        var test = await _dataContext.Tests.FirstOrDefaultAsync(x=>x.Id==model.TestId);
        if(test==null) return new Response<AddStudentTestDto>(System.Net.HttpStatusCode.NotFound,"Student not found !");
        foreach (var questionDto in model.QuestionDtos)
        {
            var question = new StudentTestQuestion
            {

            };
            
            foreach (var answerDto in questionDto.AnswerDtos)
            {
                var answer = await _dataContext.Answers.FirstOrDefaultAsync(x=>x.Id==answerDto.Id);
                if(answer==null) continue;

                if(answerDto.IsSelected==true && answer.IsCorrect==true)
                {
                     var newAnswer = new StudentTestQuestionAnswer
                     {
                        StudentTestResponse = StudentTestResponse.Correct,
                        IsCorrect = answer.IsCorrect,
                        Name = answer.Name,
                        IsSelected = answerDto.IsSelected,
                        StudentTestQuestionId = questionDto.Id                        
                     };
                }
                else
                {
                    var newAnswer2 = new StudentTestQuestionAnswer
                     {
                        StudentTestResponse = StudentTestResponse.InCorrect,
                        IsCorrect = answer.IsCorrect,
                        Name = answer.Name,
                        IsSelected = answerDto.IsSelected,
                        StudentTestQuestionId = question.Id                        
                     };
                }

            }
        }
        return new Response<AddStudentTestDto>(model);
    }

}
